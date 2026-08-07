using System.ComponentModel.DataAnnotations;
using Task_1.Models;

namespace Tasks.Models
{
    public class CreateAuthorDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new();
    }
}
