public static class BookProcedural
{

    public static IEnumerable<Book> GetAvailableProgrammingBooks()



    {
        var books = BookRepository.LoadBooks();
        foreach (var book in books)
        {
            if (book.Genre == "Programming" && book.IsAvailable)
            {
                yield return book;
            }

        }
    }

    public static IEnumerable<Book> GetAffordableBooksSorted()
    {
        var books = BookRepository.LoadBooks();
        var newList = new List<Book>();
        foreach (var book in books)
        {
            if (book.Price < 300)
            {
                newList.Add(book);
            }
        }
        newList.Sort((a, b) => a.Price.CompareTo(b.Price));
        return newList;

    }



public static void Print(IEnumerable<Book> source, string title)
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