namespace ExpenseTracker;

public class UpdateCommand
{

    public static void Execute(string[] args)
    {
        // Find expense
        var expenses = Storage.LoadExpenses();

        
        int id = int.Parse(CLIParser.GetArg(args, "--id"));
       
        var expense = expenses.FirstOrDefault(e => e.Id == id);

        if (expense == null)
        {
            Console.WriteLine($"Error: Expense with ID {id} not found.");
            return;
        }

        // Declare Variables for options
        string description = CLIParser.GetArg(args, "--description");
        string amountArg = CLIParser.GetArg(args, "--amount");
        string category = CLIParser.GetArg(args, "--category");

        bool updated = false;

        if (!string.IsNullOrWhiteSpace(description))
        {
            expense.Description = description;
            updated = true;
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            expense.Category = category;
            updated = true;
        }

        if (!string.IsNullOrWhiteSpace(amountArg))
        {
            if (!decimal.TryParse(amountArg, out decimal amount))
            {
                Console.WriteLine("Error: Invalid amount value.");
                return;
            }

            expense.Amount = amount;
            updated = true;
        }
        if (!updated)
        {
            Console.WriteLine(
                "Error: No update options provided. Use --description, --amount, or --category."
            );
            return;
        }

        Storage.SaveExpenses(expenses);
        Console.WriteLine($"Expense with ID {id} updated successfully.");
    }

}
