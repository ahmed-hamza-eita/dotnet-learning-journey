using Microsoft.EntityFrameworkCore;

namespace InitialMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Data.AppDbContext())
            {
                foreach (var item in context.Sections.Include(x => x.Course))
                {
                    Console.WriteLine($"Section: {item.SectionName}, " +
                        $"Course {item.Course.CourseName}");
                }
            }
        }
    }
}
