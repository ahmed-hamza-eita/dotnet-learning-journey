

namespace _18_SaveData.Entities
{
    public class Book : AduitableEntity ,ISoftDeletable 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        //Requried
        public int AuthorId { set; get; }
        public Author Author { set; get; }


        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
