
namespace InitialMigration.Entities
{
    public class Section
    {
        public int  Id { set; get; }
        public string? SectionName { set; get; }

        //1:M (required)
        public int CourseId { set; get; }
        public Course Course { set; get; }

        //1:M (optional)
        public int? InstructorId { set; get; }
        public Instructor? Instructor { set; get; }
    }
}
