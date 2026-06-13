
    public static class BookRepository
    {
        public static List<Book> LoadBooks()
        {
            return new List<Book>
            {
                new Book { Id=1, Title="Clean Code", Author="Robert Martin", Genre="Programming", Price=250, IsAvailable=true, Year=2008 },
                new Book { Id=2, Title="Harry Potter", Author="J.K. Rowling", Genre="Fiction", Price=150, IsAvailable=false, Year=1997 },
                new Book { Id=3, Title="The Pragmatic Programmer", Author="David Thomas", Genre="Programming", Price=300, IsAvailable=true, Year=1999 },
                new Book { Id=4, Title="Design Patterns", Author="Gang of Four", Genre="Programming", Price=400, IsAvailable=true, Year=1994 },
                new Book { Id=5, Title="1984", Author="George Orwell", Genre="Fiction", Price=100, IsAvailable=true, Year=1949 },
            };
        }
    }
