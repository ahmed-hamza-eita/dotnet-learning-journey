
using ECommerce.Core.DTO.Identity;

namespace ECommerce.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthResultDTO> Register(RegisterDTO dto);
        Task<AuthResultDTO> Login(LoginDTO dto);
      
        Task<bool> ForgetPassword(string email);
        Task<AuthResultDTO> ResetPassword(ResetPasswordDTO dto);

        Task<AuthResultDTO> ActiveAccount(ActivateEmailDTO dto);
    }
}
