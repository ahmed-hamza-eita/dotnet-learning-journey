
namespace ECommerce.Core.DTO.Identity
{
    public class ResetPasswordDTO:LoginDTO
    {
        
        public string Token { set; get; } = string.Empty;
    }
}
