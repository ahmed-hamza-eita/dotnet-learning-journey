using Microsoft.EntityFrameworkCore;
using Task_1.Models;
using Tasks.Models;

namespace Task_1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { set; get; }
        public DbSet<Author> Authors { set; get; }

        //DateOnly Converter
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
    }
}
