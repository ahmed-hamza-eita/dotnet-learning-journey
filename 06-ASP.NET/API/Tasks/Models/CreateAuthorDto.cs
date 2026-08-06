using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class CreateAuthorDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
