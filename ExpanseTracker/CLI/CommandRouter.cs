using ExpenseTracker.Services;
using ExpenseTracker.Storage;

namespace ExpenseTracker.CLI;

public static class CommandRouter
{
    internal static readonly ExpenseService Service =
        new(new ExpenseRepository());

    public static void Route(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No command provided.");
            return;
        }

        switch (args[0])
        {
            case "add":
                ExpenseCommands.HandleAdd(args);
                break;

            case "list":
                ExpenseCommands.HandleList(args);
                break;

            case "summary":
                ExpenseCommands.HandleSummary(args);
                break;

            case "delete":
                ExpenseCommands.HandleDelete(args);
                break;

            case "budget":
                ExpenseCommands.HandleBudget(args);
                break;

            case "export":
                ExpenseCommands.HandleExport(args);
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}
