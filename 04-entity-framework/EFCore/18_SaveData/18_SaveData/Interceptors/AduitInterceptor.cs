using _18_SaveData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace _18_SaveData.Interceptors
{
    /*
    public class AduitInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUser;
        public AduitInterceptor(ICurrentUserService currentUser)
        {
            _currentUser = currentUser;
        }
        public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, InterceptionResult<int> result)
        {
            var context = eventData.Context;

            foreach (var entry in context.ChangeTracker.Entries<AduitableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = _currentUser.UserName;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = _currentUser.UserName;
                }
            }

            return result;
        }
    }
    */
}