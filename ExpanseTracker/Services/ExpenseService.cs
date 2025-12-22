using ExpenseTracker.Models;
using ExpenseTracker.Storage;

namespace ExpenseTracker.Services;

public class ExpenseService
{
    private readonly ExpenseRepository _repo;
    private readonly Dictionary<int, MonthlyBudget> _budgets = new();

    public ExpenseService(ExpenseRepository repo)
    {
        _repo = repo;
    }

    public Expense AddExpense(string description, decimal amount, string category)
    {
        var expense = _repo.Add(description, amount, category);
        CheckBudget(expense);
        return expense;
    }

    public List<Expense> ListExpenses(string? category = null)
    {
        return string.IsNullOrEmpty(category)
            ? _repo.GetAll()
            : _repo.GetAll().Where(e => e.Category == category).ToList();
    }

    public decimal GetTotal(int? month = null)
    {
        var expenses = _repo.GetAll();
        if (month.HasValue)
            expenses = expenses
                .Where(e => e.Date.Month == month.Value &&
                            e.Date.Year == DateTime.Now.Year)
                .ToList();

        return expenses.Sum(e => e.Amount);
    }

    public bool DeleteExpense(int id) => _repo.Delete(id);

    public void SetBudget(int month, decimal amount)
    {
        _budgets[month] = new MonthlyBudget { Month = month, Amount = amount };
    }

    private void CheckBudget(Expense expense)
    {
        int month = expense.Date.Month;
        if (!_budgets.ContainsKey(month)) return;

        decimal total = GetTotal(month);
        if (total > _budgets[month].Amount)
        {
            Console.WriteLine("⚠ Warning: Monthly budget exceeded!");
        }
    }

    public void ExportCsv(string file)
    {
        using var writer = new StreamWriter(file);
        writer.WriteLine("Id,Date,Description,Category,Amount");

        foreach (var e in _repo.GetAll())
        {
            writer.WriteLine($"{e.Id},{e.Date:yyyy-MM-dd},{e.Description},{e.Category},{e.Amount}");
        }
    }
}
