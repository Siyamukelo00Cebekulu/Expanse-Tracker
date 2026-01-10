using System.Security.Cryptography.X509Certificates;

namespace ExpenseTracker;

public class DeleteCommand
{
    public static void Execute(string[] args)
    {
        var expenses = Storage.LoadExpenses();

        int id = int.Parse(CLIParser.GetArg(args, "--id"));

        var expense = expenses.FirstOrDefault(e => e.Id == id);

        bool deleted = expense != null;

        if(expense != null)
        {
            expenses.Remove(expense);
            Storage.SaveExpenses(expenses);
        }

        Console.WriteLine(
            deleted
                ? "Expense deleted successfully"
                : "Expense not found"
        );
    }
}
