using System.ComponentModel.DataAnnotations;

namespace Task_1.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Author { get; set; } = string.Empty;

        public DateOnly PublishedDate { get; set; }
    }
}
