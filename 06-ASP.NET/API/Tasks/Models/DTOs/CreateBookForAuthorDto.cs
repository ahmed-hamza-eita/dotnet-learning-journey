using System.ComponentModel.DataAnnotations;

namespace Tasks.Models.DTOs
{
    public class CreateBookForAuthorDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "PublishedDate is required.")]
        public DateOnly PublishedDate { get; set; }
    }
}
