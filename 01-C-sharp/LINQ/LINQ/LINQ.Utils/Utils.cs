namespace LINQ.Utils;

public static class Utils
{
    public static void Print<T>(this IEnumerable<T> source, string title)
    {
        Console.WriteLine();
        Console.WriteLine("┌───────────────────────────────────────────────────────┐");
        Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
        Console.WriteLine("└───────────────────────────────────────────────────────┘");
        foreach (var item in source)
            Console.WriteLine(item);
    }
}