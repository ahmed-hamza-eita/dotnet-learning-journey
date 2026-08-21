using ECommerce.Core.Entities.Products;
using ECommerce.Core.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace ECommerce.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<Category> Categories { set; get; }
        public virtual DbSet<Photo> Photos { set; get; }
        public virtual DbSet<Address> Addresses { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
