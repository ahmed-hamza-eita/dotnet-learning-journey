

namespace QueryData.Entities
{
   public class Review
    {
        public int Id { set; get; }
        public string Feedback { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
