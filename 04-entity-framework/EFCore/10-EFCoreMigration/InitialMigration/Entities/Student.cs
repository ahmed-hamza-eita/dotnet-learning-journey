

namespace InitialMigration.Entities
{
    public class Student
    {
        public int  Id { set; get; }
        public string? FName { set; get; }
        public string? LName { set; get; }



        public ICollection<Section> Sections = new List<Section>();
    }
}
