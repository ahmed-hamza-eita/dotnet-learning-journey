using Microsoft.AspNetCore.Identity;


namespace ECommerce.Core.Entities.User
{
    public class AppUser : IdentityUser
    {
        public string? DisplayName { set; get; }
        public Address? Address { set; get; }
    }
}
