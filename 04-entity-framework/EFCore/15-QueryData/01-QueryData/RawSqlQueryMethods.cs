using Microsoft.EntityFrameworkCore;
using QueryData.Data;


namespace QueryData
{
    public static class RawSqlQueryMethods
    {
        internal static void FromSqlRaw(AppDbContext context)
        {
            var getCoursesV1 = context.Courses.FromSql($"SELECT * FROM dbo.courses");

            var getCoursesV2 = context.Courses.FromSqlInterpolated($"SELECT * FROM dbo.courses");

            var getCoursesV3 = context.Courses.FromSqlRaw("SELECT * FROM dbo.courses");

            foreach (var i in getCoursesV1)
            {
                Console.WriteLine($"Course ID: {i.Id}, Name: {i.CourseName}");
            }
        }
    }
}
