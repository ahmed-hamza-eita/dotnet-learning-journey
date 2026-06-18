namespace LINQ.Utils;

public static class Utils
{
    public static void Print<T>(this IEnumerable<T> source, string title)
    {
        var defaultColor = Console.ForegroundColor;
        
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n┌───────────────────────────────────────────────────────┐");
        Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
        Console.WriteLine("└───────────────────────────────────────────────────────┘");
        Console.ForegroundColor = defaultColor;

        foreach (var item in source)
        {
            Console.WriteLine(item);
        }
    }

    
}