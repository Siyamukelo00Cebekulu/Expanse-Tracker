namespace ExpenseTracker;

public class ListCommand
{
    public static void Execute()
    {
        var expenses = Storage.LoadExpenses();

        Console.WriteLine("ID  Date       Description   Amount");
        foreach (var e in expenses)
        {
            Console.WriteLine($"{e.Id,-3} {e.Date:yyyy-MM-dd} {e.Description,-12} R{e.Amount}");
        }
    }
}
