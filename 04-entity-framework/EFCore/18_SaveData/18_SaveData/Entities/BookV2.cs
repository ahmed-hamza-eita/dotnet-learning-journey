 
namespace _18_SaveData.Entities
{
    public class BookV2
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //optional
        public int? AuthorV2Id { set; get; }
        public AuthorV2? AuthorV2 { set; get; }
    }
}
