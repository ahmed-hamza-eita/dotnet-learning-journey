using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.DTO
{
    public record CategoryDTO(
        [Required, MaxLength(30)] string Name,
        [Required, MaxLength(250)] string Description
    );
}
