using System.Globalization;

namespace ExpenseTracker;

public class SummaryCommand
{
    public static void Execute(string[] args)
    {

        var expenses = Storage.LoadExpenses();

        string? monthArg = CLIParser.GetArg(args, "--month");
        string? yearArg = CLIParser.GetArg(args, "--year");

        int year = DateTime.Today.Year;
        int month = 0;

        if (!string.IsNullOrWhiteSpace(monthArg))
        {
            if (!TryParseMonth(monthArg, out year, out month))
            {
                Console.WriteLine(
                    "Error: Invalid --month format. Use MM or YYYY-MM (e.g. 1 or 2025-01)."
                );
                return;
            }

            expenses = expenses
                .Where(e => e.Date.Year == year && e.Date.Month == month)
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(yearArg))
        {
            if (!int.TryParse(yearArg, out year))
            {
                Console.WriteLine("Error: Invalid --year value.");
                return;
            }

            expenses = expenses
                .Where(e => e.Date.Year == year)
                .ToList();
        }

        decimal total = expenses.Sum(e => e.Amount);

        if (monthArg == null)
        {
            Console.WriteLine($"Total expenses: {total:C}");
        }
        else
        {
            Console.WriteLine(
                $"Total expenses for {year}-{month:D2}: {total:C}"
            );
        }
    }

    private static bool TryParseMonth(string input, out int year, out int month)
    {
        year = DateTime.Today.Year;
        month = 0;

        input = input.Trim();

        // Case: Month name only (e.g. "January", "Jan")
        if (DateTime.TryParseExact(
            input,
            new[] { "MMMM", "MMM" },
            CultureInfo.InvariantCulture,
            DateTimeStyles.AllowWhiteSpaces,
            out DateTime monthNameDate))
        {
            month = monthNameDate.Month;
            return true;
        }

        // Case: Year + month name (e.g. "2025-January", "2025-Jan")
        if (DateTime.TryParseExact(
            input,
            new[] { "yyyy-MMMM", "yyyy-MMM" },
            CultureInfo.InvariantCulture,
            DateTimeStyles.AllowWhiteSpaces,
            out DateTime yearMonthNameDate))
        {
            year = yearMonthNameDate.Year;
            month = yearMonthNameDate.Month;
            return true;
        }

        // Case: MM
        if (int.TryParse(input, out int m) && m >= 1 && m <= 12)
        {
            month = m;
            return true;
        }

        // Case: YYYY-MM
        if (DateTime.TryParseExact(
            input,
            "yyyy-MM",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime numericDate))
        {
            year = numericDate.Year;
            month = numericDate.Month;
            return true;
        }

        return false;
    }
}
