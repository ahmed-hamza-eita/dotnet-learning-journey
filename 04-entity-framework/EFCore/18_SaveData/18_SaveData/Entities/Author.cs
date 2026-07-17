
namespace _18_SaveData.Entities
{
    public class Author : ISoftDeletable
    {
        public int Id { set; get; }
        public string FName { set; get; }
        public string LName { set; get; }
        public string FullName => FName + LName;
        //Requried
        public List<Book> Books { get; set; } = new();

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Encryption 
        public string? NationalId { get; set; }
    }
}
