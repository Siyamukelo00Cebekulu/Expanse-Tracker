using System.Globalization;

namespace ExpenseTracker;

public class Storage
{
    private static readonly string ExpenseFile = "expenses.csv";


    public static List<Expense> LoadExpenses()
    {
        if (!File.Exists(ExpenseFile)) return new();

        return File.ReadAllLines(ExpenseFile)
            .Select(line => line.Split(','))
            .Select(p => new Expense
            {
                Id = int.Parse(p[0]),
                Date = DateTime.Parse(p[1]),
                Description = p[2],
                Category = p[3],
                Amount = decimal.Parse(p[4], CultureInfo.InvariantCulture)
            }).ToList();
    }


    /*
        Lambda expresson!! indicator that I did not wrote this
        method, if you see ternary operator as well just know.
    */
    public static void SaveExpenses(List<Expense> expenses)
    {
        var lines = expenses.Select(e =>
            $"{e.Id},{e.Date:yyyy-MM-dd},{e.Description},{e.Category},{e.Amount}");
        File.WriteAllLines(ExpenseFile, lines);
    }

}
