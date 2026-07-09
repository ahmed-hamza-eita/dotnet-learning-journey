namespace QueryData.Entities
{
    
   public class Course
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Section> Sections { get; set; } = new List<Section>(); 

         public override string ToString()
        {
            return $"Id: {Id}, Name: {CourseName}, Price: {Price:C}";
        }

    }
}
