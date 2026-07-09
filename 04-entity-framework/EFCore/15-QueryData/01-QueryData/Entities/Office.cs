

namespace QueryData.Entities
{
    public class Office
    {
        public int Id { get; set; }
        public string? OfficeName { get; set; }
        public string? OfficeLocation { get; set; }

        public virtual Instructor? Instructor { get; set; } 

    }
}
