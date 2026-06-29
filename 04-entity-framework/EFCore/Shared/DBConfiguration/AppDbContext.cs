using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Models;

namespace Shared.DBConfiguration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").Build();
            var connectionStr = configuration.GetSection("DefaultConnection").Value;

            optionsBuilder.UseSqlServer(connectionStr);
        }
    }
}
