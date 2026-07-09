using Microsoft.EntityFrameworkCore;
using QueryData.Data;

namespace QueryData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //GetAllCourses(context);

                // GetSections(context);

                tracking(context);
                nonTracking(context);


            }
        }

        private static void nonTracking(AppDbContext context)
        {
            //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var course = context.Courses.AsNoTracking().SingleOrDefault(x => x.Id == 6);
            Console.WriteLine($"Before non track {course.CourseName}");
            course.CourseName = "English";
            Console.WriteLine($"After non track {course.CourseName}");
            context.SaveChanges(); //not applied on db server
        }

        private static void tracking(AppDbContext context)
        {
            var course = context.Courses.SingleOrDefault(x => x.Id == 6);
            Console.WriteLine($"Before track {course.CourseName}");
            course.CourseName = "Math";
            Console.WriteLine($"After track {course.CourseName}");
            context.SaveChanges(); //applied on db server
        }

        private static void GetSections(AppDbContext context)
        {
            var getSections = context.Sections.AsNoTracking().Where(s => s.CourseId == 6).Select(s => new
            {
                CourseId = s.Course.Id,
                Id = s.Id,
                SectionName = s.SectionName,
                CourseName = s.Course.CourseName,

            }).Take(3);

            foreach (var item in getSections)
            {
                Console.WriteLine($"SectionId: {item.Id},CourseId: {item.CourseId}, Name: {item.SectionName}, CourseName: {item.CourseName}");
            }
        }



        private static void GetAllCourses(AppDbContext context)
        {
            var allCourses = context.Courses;

            foreach (var item in allCourses)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.CourseName}, Price: {item.Price:C}");
            }
        }
    }
}
