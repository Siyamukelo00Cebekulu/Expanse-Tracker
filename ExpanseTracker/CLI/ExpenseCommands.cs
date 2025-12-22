namespace ExpenseTracker.CLI;

internal static class ExpenseCommands
{
    public static void HandleAdd(string[] args)
    {
        string description = GetArg(args, "--description");
        decimal amount = decimal.Parse(GetArg(args, "--amount"));
        string category = GetArg(args, "--category", "General");

        var expense = CommandRouter.Service
            .AddExpense(description, amount, category);

        Console.WriteLine($"Expense added successfully (ID: {expense.Id})");
    }

    public static void HandleList(string[] args)
    {
        Console.WriteLine("ID  Date        Description  Amount");

        foreach (var e in CommandRouter.Service.ListExpenses())
        {
            Console.WriteLine(
                $"{e.Id}   {e.Date:yyyy-MM-dd}  {e.Description}  R{e.Amount}"
            );
        }
    }

    public static void HandleSummary(string[] args)
    {
        string? monthArg = GetArg(args, "--month", null);

        decimal total = monthArg == null
            ? CommandRouter.Service.GetTotal()
            : CommandRouter.Service.GetTotal(int.Parse(monthArg));

        Console.WriteLine($"Total expenses: R{total}");
    }

    public static void HandleDelete(string[] args)
    {
        int id = int.Parse(GetArg(args, "--id"));

        bool deleted = CommandRouter.Service.DeleteExpense(id);

        Console.WriteLine(
            deleted
                ? "Expense deleted successfully"
                : "Expense not found"
        );
    }

    public static void HandleBudget(string[] args)
    {
        int month = int.Parse(GetArg(args, "--month"));
        decimal amount = decimal.Parse(GetArg(args, "--amount"));

        CommandRouter.Service.SetBudget(month, amount);

        Console.WriteLine("Monthly budget set");
    }

    public static void HandleExport(string[] args)
    {
        string file = GetArg(args, "--file");

        CommandRouter.Service.ExportCsv(file);

        Console.WriteLine("Expenses exported successfully");
    }

    private static string GetArg(
        string[] args,
        string key,
        string? defaultValue = ""
    )
    {
        int index = Array.IndexOf(args, key);

        return index >= 0 && index + 1 < args.Length
            ? args[index + 1]
            : defaultValue ?? "";
    }
}
