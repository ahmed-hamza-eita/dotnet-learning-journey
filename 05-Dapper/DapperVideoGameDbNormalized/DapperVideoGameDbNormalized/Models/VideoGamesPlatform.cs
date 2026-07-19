namespace DapperVideoGameDbNormalized.Models
{
    public class VideoGamesPlatform
    {
        public int VideoGameId { get; set; }
        public int PlatformId { get; set; }

        // Navigation properties
        public VideoGame? VideoGame { get; set; }
        public Platform? Platform { get; set; }
    }
}
