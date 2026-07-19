namespace DapperVideoGameDbNormalized.Models
{
    public class Platform
    {
        public int Id { set; get; }
        public required string Name { set; get; }

        // Navigation property
        public List<VideoGame> VideoGames { get; set; } = [];
    }
}
