 
namespace ECommerce.Core.DTO.Identity
{
    public class ActivateEmailDTO
    {
        public string Token { set; get; } = string.Empty;
        public string Email { set; get; } = string.Empty;
    }
}
