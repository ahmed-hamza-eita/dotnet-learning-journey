static class BookFunctional
{
    public static IEnumerable<Book> Filter
    (IEnumerable<Book> dataSource, Func<Book, bool> predicate)
    {

        foreach (var book in dataSource)
        {
            if (predicate(book))
            {
                yield return book;
            }
        }
    }
    public static void Print(this IEnumerable<Book> source, string title)
    {
        if (source == null) return;
        Console.WriteLine();
        Console.WriteLine("┌───────────────────────────────────────────────────────┐");
        Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
        Console.WriteLine("└───────────────────────────────────────────────────────┘");
        foreach (var book in source)
            Console.WriteLine(book);
    }
}