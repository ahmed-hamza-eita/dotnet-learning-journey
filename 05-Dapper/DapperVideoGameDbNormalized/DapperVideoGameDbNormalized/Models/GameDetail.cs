namespace DapperVideoGameDbNormalized.Models
{
    public class GameDetail
    {
        public int VideoGameId { set; get; }
        public required string Rating { set; get; }
        public required string Description { set; get; }

        // Navigation property
        public VideoGame? VideoGame { get; set; }
    }

}
