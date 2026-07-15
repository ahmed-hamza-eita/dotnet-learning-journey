

namespace _18_SaveData.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { set; get; }
        public Author Author { set; get; }
    }
}
