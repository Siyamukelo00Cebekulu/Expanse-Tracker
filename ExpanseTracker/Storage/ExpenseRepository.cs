using ExpenseTracker.Models;

namespace ExpenseTracker.Storage;

public class ExpenseRepository
{
    private readonly List<Expense> _expenses = new();
    private int _nextId = 1;

    public Expense Add(string description, decimal amount, string category)
    {
        var expense = new Expense
        {
            Id = _nextId++,
            Description = description,
            Amount = amount,
            Category = category
        };
        _expenses.Add(expense);
        return expense;
    }

    public List<Expense> GetAll() => _expenses;

    public Expense? GetById(int id) =>
        _expenses.FirstOrDefault(e => e.Id == id);

    public bool Delete(int id)
    {
        var expense = GetById(id);
        if (expense == null) return false;
        _expenses.Remove(expense);
        return true;
    }
}
