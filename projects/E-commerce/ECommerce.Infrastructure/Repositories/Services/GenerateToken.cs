

using ECommerce.Core.Entities.User;
using ECommerce.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Infrastructure.Repositories.Services
{
    public class GenerateToken : IGenerateToken
    {
        private readonly IConfiguration _configuration;

        public GenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  string  GetAndGenerateToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>() {
            new Claim (ClaimTypes.Name,user.UserName!),
            new Claim (ClaimTypes.Email,user.Email!),
            };

            var security = GetRequiredConfig("Token:Secret");
            var key = Encoding.ASCII.GetBytes(security);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                Issuer = GetRequiredConfig("Token:Issuer"),
                SigningCredentials = credentials,
                NotBefore = DateTime.Now
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private string GetRequiredConfig(string key)
           => _configuration[key] ?? throw new InvalidOperationException($"{key} is missing from configuration");
    }
}
