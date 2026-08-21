
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.DTO.Identity
{
    public class RegisterDTO
    {
        [Required, EmailAddress]
        public string Email { set; get; } = string.Empty;

        [Required, MinLength(3)]
        public string UserName { set; get; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { set; get; } = string.Empty;
    }
}
