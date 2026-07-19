namespace DapperVideoGameDbNormalized.Models
{
    public class Review
    {
        public int Id { set; get; }
        public int VideoGameId { set; get; }
        public required string ReviewerName { set; get; }
        public required string Content { set; get; }
        public int Rating { set; get; }
        // Navigation property
        public VideoGame? VideoGame { get; set; }
    }
}
