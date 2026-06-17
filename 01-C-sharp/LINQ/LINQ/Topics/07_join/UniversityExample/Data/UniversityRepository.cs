public static class UniversityRepository
{
    public static IEnumerable<Student> LoadStudents()
    {
        return new List<Student>
        {
            new Student { Id = 1, Name = "Ahmed",  CourseId = 1 },
            new Student { Id = 2, Name = "Sara",   CourseId = 2 },
            new Student { Id = 3, Name = "Ali",    CourseId = 1 },
            new Student { Id = 4, Name = "Mona",   CourseId = null }
        };
    }

    public static IEnumerable<Course> LoadCourses()
    {
        return new List<Course>
        {
            new Course { Id = 1, Title = "C# Basics" },
            new Course { Id = 2, Title = "ASP.NET Core" },
            new Course { Id = 3, Title = "SQL Server" }
        };
    }
}