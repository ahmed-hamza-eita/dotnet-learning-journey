public static class JoinOperator
{

    public static void InnerJoinExample
    (IEnumerable<Student> students, IEnumerable<Course> courses)
    {
        var innerJoinResult = students.Join(
                      courses,
                      student => student.CourseId,
                      course => course.Id,
                      (student, course) => new StudentCourseDto
                      {
                          StudentName = student.Name,
                          CourseTitle = course.Title
                      }
);

        Console.WriteLine("\n--- Inner Join ---");
        foreach (var item in innerJoinResult)
        {
            Console.WriteLine($"{item.Name} {item.Title}");
        }
    }

    public static void GroupJoinExample
    (IEnumerable<Student> students, IEnumerable<Course> courses)
    {
        var groupJoinResult = courses.GroupJoin(
                students,
                course => course.Id,
                student => student.CourseId,
                (course, studentsInCourse) => new CourseWithStudentsDto
                {
                    CourseTitle = course.Title,
                    Students = studentsInCourse
                }
        );

        Console.WriteLine("\n--- Group Join ---");
        foreach (var item in groupJoinResult)
        {
            Console.WriteLine($"\nCourse: {item.Title}");
            foreach (var student in item.Students)
                Console.WriteLine($"  - {student.Name}");
        }
    }

}