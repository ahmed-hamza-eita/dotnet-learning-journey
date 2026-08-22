
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.DTO.Identity
{
    public class RegisterDTO : LoginDTO
    {


        [Required, MinLength(3)]
        public string UserName { set; get; } = string.Empty;


    }
}
