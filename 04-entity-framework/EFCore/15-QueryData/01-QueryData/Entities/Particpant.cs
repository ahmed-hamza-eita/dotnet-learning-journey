

namespace QueryData.Entities
{
    public class Participant
    {
        public int Id { set; get; }
        public string? FName { set; get; }
        public string? LName { set; get; }



        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    }

    public class Individual : Participant
    {
        public string University { get; set; }
        public int YearOfGraduation { get; set; }
        public bool IsIntern { get; set; }
    }
    public class Coporate : Participant
    {
        public string Company { get; set; }
        public string JobTitle { get; set; }
    }
}
