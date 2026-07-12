using Microsoft.EntityFrameworkCore;
using QueryData.Data;
using QueryData.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


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

                //tracking(context);
                //nonTracking(context);

                //EagerLoading(context);
                //ExplicitLoading(context);
                //LazyLoading(context);

                //ServerEvaluation(context);
                //ClientEvaluation(context);

                //Projection(context);
                //SplitQuries(context);
                //SplitQuriesByConfiguration(context);

                //Joins
                // InnerJoins(context);
                //GroupJoins(context); //left outer join
                //CrossJoin(context);

                //SelectMany(context);

                GroupBy(context);
            }
        }

        #region GroupBy
        private static void GroupBy(AppDbContext context)
        {
            //Qurey syntax
            var instructorSections = (from s in context.Sections
                                      group s by s.Instructor
                                      into g
                                      select new
                                      {
                                          key = g.Key,
                                          Sections = g.ToList()
                                      });


            //method syntax
            var instructorSectionsMethod = context.Sections.GroupBy(x => x.Instructor)
                .Select(x => new
                {
                    key = x.Key,
                    Sections = x.ToList(),
                     
                });

            foreach (var item in instructorSectionsMethod)
            {
                Console.WriteLine(item.key.FullName);
                foreach (var section in item.Sections)
                {
                    Console.WriteLine(section.SectionName);
                }
            }
        }
        #endregion

        #region SelectMany => flatten a collection of lists into a single list.
        private static void SelectMany(AppDbContext context)
        {
            //Query Syntax
            var selectStdNames = (from c in context.Courses
                                  where c.CourseName.Contains("frontend")
                                  from s in context.Sections
                                  from p in context.Participants
                                  select new
                                  {
                                      ParticipantName = $"{p.FName} {p.LName}"
                                  });
            //Method Syntax
            var selectStdNamesMethodSyntax =
                context.Courses.Where(c => c.CourseName.Contains("frontend"))
                .SelectMany(s => s.Sections)
                .SelectMany(p => p.Participants)
                .Select(p => new { ParticipantName = $"{p.FName} {p.LName}" }).ToList();


        }
        #endregion
        #region Joins
        private static void InnerJoins(AppDbContext context)
        {
            var innerJoins = context.Courses.AsNoTracking().
                   Join(context.Sections.AsNoTracking(),
                   c => c.Id,
                   s => s.CourseId,
                   (c, s) => new
                   {
                       courseName = c.CourseName,
                       dateRange = s.DateRange.ToString(),
                       timeSlot = s.TimeSlot.ToString()
                   }).ToList();
        }
        private static void GroupJoins(AppDbContext context)
        {
            //Query Syntax
            var groupJoinQuerySyntax = (from o in context.Offices
                                        join i in context.Instructors
                                        on o.Id equals i.OfficeId into officeVacancy
                                        from ov in officeVacancy.DefaultIfEmpty()
                                        select new
                                        {
                                            officeId = o.Id,
                                            officeName = o.OfficeName,
                                            location = o.OfficeLocation,
                                            instructorName = ov != null ? ov.FullName : "<<Empty>>"
                                        }).ToList();

            foreach (var i in groupJoinQuerySyntax)
            {
                Console.WriteLine($"{i.officeName} -> {i.instructorName}");
            }


            //Method Syntax
            var groupJoinMethodSyntax = context.Offices.GroupJoin(context.Instructors,
                o => o.Id,
                i => i.OfficeId,
                (office, instructorGroup) => new { office, instructorGroup }
                )
                .SelectMany(
                officeWithGroup => officeWithGroup.instructorGroup.DefaultIfEmpty(),
                (officeWithGroup, instructor) => new
                {
                    OfficeId = officeWithGroup.office.Id,
                    officeName = officeWithGroup.office.OfficeName,
                    Location = officeWithGroup.office.OfficeLocation,
                    instructorName = instructor != null ? instructor.FullName : "<<EMPTY>>"
                }
                ).ToList();
            foreach (var i in groupJoinMethodSyntax)
            {
                Console.WriteLine($"{i.officeName} -> {i.instructorName}");
            }
        }
        private static void CrossJoin(AppDbContext context)
        {
            // Query Syntax
            var crossJoinQuerySyntax = (from s in context.Sections
                                        from i in context.Instructors
                                        select new
                                        {
                                            s.SectionName,
                                            i.FullName
                                        }).ToList();
            Console.WriteLine(crossJoinQuerySyntax.Count());

            var crossJoinMethodSyntax = context.Sections.SelectMany(
                i => context.Instructors,
                (s, i) => new
                {
                    s.SectionName,
                    i.FullName
                }).ToList();
            Console.WriteLine(crossJoinMethodSyntax.Count());

        }
        #endregion
        private static void SplitQuriesByConfiguration(AppDbContext context)
        {
            var courseProjection = context.Courses.AsNoTracking()
               .Include(x => x.Sections)
               .Include(x => x.Reviews);
        }
        #region SplitQuries
        private static void SplitQuries(AppDbContext context)
        {
            var courseProjection = context.Courses.AsNoTracking()
                .Include(x => x.Sections)
                .Include(x => x.Reviews)
                .AsSplitQuery();
        }

        private static void Projection(AppDbContext context)
        {
            var courseProjection = context.Courses.AsNoTracking().
                Select(c => new
                {
                    CourseId = c.Id,
                    CourseName = c.CourseName,
                    Hours = c.Price,
                    Section = c.Sections.Select(s => new
                    {
                        SectionName = s.SectionName,
                        SectionId = s.Id,
                        Date = s.DateRange.ToString(),
                        TimeSlots = s.TimeSlot.ToString()
                    }),
                    Reviews = c.Reviews.Select(r => new
                    {
                        Feedback = r.Feedback,
                        CreatedAt = r.CreatedAt
                    })
                });

        }
        #endregion

        #region Client vs Server side Evaluation
        private static void ServerEvaluation(AppDbContext context)
        {
            Console.WriteLine("Server Evaluation");
            var getSections = context.Sections.Where(s => s.CourseId == 6).Select(s => new
            {
                CourseId = s.Course.Id,
                Id = s.Id,
                SectionName = s.SectionName,
                CourseName = s.Course.CourseName,
                // This will be translated entirely into SQL Query by DATEDIFF Function in SQL Server.
                TotalDays = s.DateRange.EndDate.DayNumber - s.DateRange.StartDate.DayNumber
            }).Take(3);

            foreach (var item in getSections)
            {
                Console.WriteLine($"{item.Id} {item.SectionName} Total Days: ({item.TotalDays})");
            }
        }

        private static void ClientEvaluation(AppDbContext context)
        {
            Console.WriteLine("Client Evaluation");
            //A custom C# method that the database doesn't understand  (CalculateTotalDays)
            var getSections = context.Sections.Where(s => s.CourseId == 6).Select(s => new
            {
                CourseId = s.Course.Id,
                Id = s.Id,
                SectionName = s.SectionName,
                CourseName = s.Course.CourseName,
                // Client evaluation: EF Core fetches Dates, 
                // then runs the custom C# method in memory.
                TotalDays = s.DateRange != null
                         ? CalculateTotalDays(s.DateRange.StartDate, s.DateRange.EndDate)
                         : 0

            }).Take(3);

            foreach (var item in getSections)
            {
                Console.WriteLine($"{item.Id} {item.SectionName}  Total Days: ({item.TotalDays})");
            }
        }
        private static int CalculateTotalDays(DateOnly startDate, DateOnly endDate)
        {
            return endDate.DayNumber - startDate.DayNumber;
        }

        #endregion

        #region Loading Related Data
        private static void LazyLoading(AppDbContext context)
        {
            var section = context.Sections.FirstOrDefault(x => x.Id == 1);
            foreach (var participant in section.Participants)
                Console.WriteLine($"[{participant.Id}] {participant.FName} {participant.LName}");
        }

        private static void ExplicitLoading(AppDbContext context)
        {
            var section = context.Sections.FirstOrDefault(x => x.Id == 1);
            var queryParticipants = context.Entry(section).Collection(x => x.Participants).Query();

            foreach (var participant in queryParticipants)
                Console.WriteLine($"[{participant.Id}] {participant.FName} {participant.LName}");
        }

        private static void EagerLoading(AppDbContext context)
        {
            var secttionParticipants = context.Sections
                .Include(x => x.Participants)
                .FirstOrDefault(x => x.Id == 9);

            foreach (var participant in secttionParticipants.Participants)
            {
                Console.WriteLine($"[{participant}] {participant.FName} {participant.LName}");
            }
        }
        #endregion

        #region Tracking vs non-Tracking
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

        #endregion


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


        #region Query Data
        private static void GetAllCourses(AppDbContext context)
        {
            var allCourses = context.Courses;

            foreach (var item in allCourses)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.CourseName}, Price: {item.Price:C}");
            }
        }
        #endregion
    }
}
