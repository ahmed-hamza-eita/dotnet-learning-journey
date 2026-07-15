
namespace _18_SaveData.Entities
{
    public class Author
    {
        public int Id { set; get; }
        public string FName { set; get; }
        public string LName { set; get; }
        public string FullName => FName + LName;
        public List<Book> Books { get; set; } = new();

    }
}
