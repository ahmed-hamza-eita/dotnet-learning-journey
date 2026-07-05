using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;


namespace InitialMigration.Data
{
    class AppDbContext : DbContext
    {

        public DbSet<Course> Courses { set; get; }
        public DbSet<Instructor> Instructors { set; get; }
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

            var configuration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").Build();

            var connectionString = configuration.GetSection("DefaultConnection").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
