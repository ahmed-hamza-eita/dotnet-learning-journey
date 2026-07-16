
using _18_SaveData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace _18_SaveData.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { set; get; }
        public DbSet<Author> Authors { set; get; }
        public DbSet<BookV2> BooksV2 { set; get; }
        public DbSet<AuthorV2> AuthorsV2 { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
               Assembly.GetExecutingAssembly()
               );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("Data/appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information); ;
        }
    }
}
