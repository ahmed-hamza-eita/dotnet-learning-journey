
namespace QueryData.Entities
{
     
        public class Section
        {
            public int Id { set; get; }
            public string? SectionName { set; get; }

            //1:M (required)
            public int CourseId { set; get; }
            public virtual Course Course { set; get; }

            //1:M (optional)
            public int? InstructorId { set; get; }
            public virtual Instructor? Instructor { set; get; }

            // m:m
            public virtual ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();
            public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

            public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {SectionName} ";
        }
    }
    }
 

     