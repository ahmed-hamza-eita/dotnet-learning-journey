using System.ComponentModel.DataAnnotations;

namespace Task_1.Models
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required.")]
        [MaxLength(50)]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "PublishedDate is required.")]
        public DateOnly PublishedDate { get; set; }
    }
}
