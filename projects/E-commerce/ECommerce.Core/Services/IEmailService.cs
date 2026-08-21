
using ECommerce.Core.DTO.Identity;

namespace ECommerce.Core.Services
{
    public interface IEmailService
    {
        Task SendEmail(EmailDTO dto);
    }
}
