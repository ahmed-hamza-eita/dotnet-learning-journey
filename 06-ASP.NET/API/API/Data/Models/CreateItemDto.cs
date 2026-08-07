using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Models
{
    public class CreateItemDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50)]
        public string? Name { set; get; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { set; get; }

        [MaxLength(50)]
        public string? Note { set; get; }

        public IFormFile? Image { set; get; }
        public int categoryId { set; get; }

    }
}
