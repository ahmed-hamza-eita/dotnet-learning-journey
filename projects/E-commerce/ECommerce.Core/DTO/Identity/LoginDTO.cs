 
using System.ComponentModel.DataAnnotations;
 

namespace ECommerce.Core.DTO.Identity
{
    public class LoginDTO
    {
        [Required, EmailAddress]
        public string Email { set; get; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { set; get; } = string.Empty;
    }
}
