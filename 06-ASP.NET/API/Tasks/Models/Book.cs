using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasks.Models;

namespace Task_1.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public DateOnly PublishedDate { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author? Author { get; set; }
    }
}
