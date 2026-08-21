
using ECommerce.Core.DTO.Identity;

namespace ECommerce.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthResultDTO> Register(RegisterDTO dto);
    }
}
