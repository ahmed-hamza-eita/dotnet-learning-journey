namespace DapperCourse.Models
{
    public class VideoGame
    {
        public int Id { set; get; }
        public required string Title { set; get; }
        public required string Publisher { set; get; }
        public required string Developer { set; get; }
        public required string Platform { set; get; }
        public required DateTime ReleaseDate { set; get; }



    }
}
