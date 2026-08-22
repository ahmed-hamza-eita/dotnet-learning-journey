using ECommerce.Core.DTO.Identity;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Core.Sharing;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthRepository(UserManager<AppUser> userManager, IEmailService emailService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
        }

        public async Task<AuthResultDTO> Register(RegisterDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName) ||
               string.IsNullOrWhiteSpace(dto.Email) ||
               string.IsNullOrWhiteSpace(dto.Password))
            {
                return new AuthResultDTO(false, "Username, email and password are required");
            }

            if (await _userManager.FindByNameAsync(dto.UserName) is not null)
            {
                return new AuthResultDTO(false, "This username is already registered");
            }

            if (await _userManager.FindByEmailAsync(dto.Email) is not null)
            {
                return new AuthResultDTO(false, "This email is already registered");
            }

            AppUser newUser = new AppUser
            {
                Email = dto.Email,
                UserName = dto.UserName
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password!);

            if (!result.Succeeded)
                return new AuthResultDTO(false, result.Errors.First().Description);

            string code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            await SendConfirmationEmail(newUser.Email, code, "active", "ActiveEmail", "Please Active your E-mail");

            return new AuthResultDTO(true, "Registration successful");
        }
        private async Task SendConfirmationEmail(string email, string code, string componenet, string subject, string message)
        {
            var result = new EmailDTO(
                to:email,
                "aheita4@gmail.com",
                subject,
                EmailStringBody.send(email, code, componenet, message)
                );
            await _emailService.SendEmail(result);
        }

    }
}
