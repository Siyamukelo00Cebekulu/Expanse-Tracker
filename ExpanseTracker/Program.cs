
using ExpenseTracker;

class Program
{
    static void Main(string[] args)
    {
        // happy path
        var argsList = args.ToList();
        if (!argsList.Any()) return;

        switch (argsList[0])
        {
            case "add":
                AddCommand.Execute(args);
                break;
            case "list":
                ListCommand.Execute();
                break;
            case "summary":
                break;
            case "delete":
                DeleteCommand.Execute(args);
                break;
            case "budget":
                break;
        }
    }
}
