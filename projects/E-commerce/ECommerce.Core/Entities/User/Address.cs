
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Core.Entities.User
{
    public class Address : BaseEntity<int>
    {
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? City { set; get; }
        public string? Street { set; get; }
        public string? State { set; get; }
        public string? ZipCode { set; get; }
                      
        public string? AppUserId { set; get; }
        [ForeignKey(nameof(AppUserId))]
        public virtual AppUser? AppUser { set; get; }
    }
}
