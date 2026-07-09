

namespace QueryData.Entities
{

    public class Instructor
    {
        public int Id { get; set; }

        public string?  Name { get; set; }
        public int? OfficeId { get; set; }
        public virtual Office? Office { get; set; }

        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    }
}
