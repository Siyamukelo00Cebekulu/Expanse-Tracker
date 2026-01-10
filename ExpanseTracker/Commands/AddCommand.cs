using System;

namespace ExpenseTracker;

public class AddCommand
{
    
    
    public static void Execute(string[] args)
    {

        string description = CLIParser.GetArg(args, "--description");
        decimal amount = decimal.Parse(CLIParser.GetArg(args, "--amount"));
        string category = CLIParser.GetArg(args, "--category", "General");

        var expenses = Storage.LoadExpenses();
        
        // Change to assign the lowest Available ID
        int id = expenses.Any() ? expenses.Max(e => e.Id) + 1 : 1;

        expenses.Add(new Expense
        {
            Id = id,
            Date = DateTime.Today,
            Description = description,
            Category = category,
            Amount = amount
        });

        Storage.SaveExpenses(expenses);
        Console.WriteLine($"Expense added successfully (ID: {id})");
    }
}
