using Microsoft.EntityFrameworkCore;

namespace Task_1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
