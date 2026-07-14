using Microsoft.Data.SqlClient;
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

            //foreach (var i in getCoursesV1)
            //{
            //    Console.WriteLine($"Course ID: {i.Id}, Name: {i.CourseName}");
            //}

            ////pass parameter
            var courseIdParam = new SqlParameter("@courseId", 1);
            var getCourseV1 = context.Courses
                .FromSqlRaw("SELECT * FROM dbo.courses WHERE Id = @courseId", courseIdParam)
                .FirstOrDefault();
            Console.WriteLine(getCourseV1);


            var getCourseV2 = context.Courses
                .FromSql($"SELECT * FROM dbo.courses WHERE Id = {1}")  //safety
                .FirstOrDefault();
            Console.WriteLine(getCourseV2);
        }


        internal static void CallingStoredProcedure(AppDbContext context)
        {
            var startDateParam = new SqlParameter("@startDate", System.Data.SqlDbType.Date)
            {
                Value = new DateTime(2023, 01, 01)
            };
            var endDateParam = new SqlParameter("@endtDate", System.Data.SqlDbType.Date)
            {
                Value = new DateTime(2025, 01, 01)
            };

            var getSectionDetails = context.SectionDetails
                .FromSql($"Exec dbo.sp_GetSectionWithinDateRange {startDateParam},{endDateParam}")
                .ToList();

            foreach (var i in getSectionDetails)
            {
                Console.WriteLine(i);
            }
        }
        internal static void CallingDbView(AppDbContext context)
        {

            var getCoursesOverviews = context.CourseOverview.ToList();
            foreach (var i in getCoursesOverviews)
            {

                Console.WriteLine(i);
            }
        }

        internal static void CallingUserDefiendFunction(AppDbContext context)
        {
            var instrcutors = context.Instructors.Select(x => new
            {
                Id = x.Id,
                FullName = x.FullName,
                Status = AppDbContext.GetInstructorAvailability(
                    x.Id,
                    new DateTime(2023,01,01),
                    new DateTime(2023, 07,09),
                    new TimeSpan(02,00,00),
                    new TimeSpan(06, 00, 00))
            }).ToList();

            foreach (var i in instrcutors) {
                Console.WriteLine(i);
            }
        }

        internal static void CallingTableValuedFunction(AppDbContext context)
        {
            var sectionsExceeding = context.GetSectionsExceedingParticipantCount(15);

            foreach (var section in sectionsExceeding)
            {
                Console.WriteLine($"{section.Id}\t{section.SectionName}\t{section.DateRange}");
            }
        }

        internal static void HasQueryFilter(AppDbContext context)
        {
            var latestSections = context.Sections;

            foreach (var section in latestSections)
            {
                Console.WriteLine($"{section.Id}\t{section.SectionName}\t{section.DateRange}");
            }
        }
    }
}