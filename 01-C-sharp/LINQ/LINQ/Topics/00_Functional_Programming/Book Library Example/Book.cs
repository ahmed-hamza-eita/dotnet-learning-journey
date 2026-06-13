{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Title.PadRight(30)}\t{Author.PadRight(20)}\t{Genre.PadRight(15)}\t${Price}\t{(IsAvailable ? "Available" : "Not Available")}\t{Year}";
        }
    }
