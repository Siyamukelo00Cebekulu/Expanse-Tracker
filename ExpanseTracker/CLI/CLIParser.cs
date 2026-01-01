namespace ExpenseTracker;

public class CLIParser
{
    public static string GetArg(
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
