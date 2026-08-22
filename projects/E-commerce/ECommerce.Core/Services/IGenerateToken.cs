
using ECommerce.Core.Entities.User;

namespace ECommerce.Core.Services
{
    public interface IGenerateToken
    {
         string  GetAndGenerateToken(AppUser user);
    }
}
