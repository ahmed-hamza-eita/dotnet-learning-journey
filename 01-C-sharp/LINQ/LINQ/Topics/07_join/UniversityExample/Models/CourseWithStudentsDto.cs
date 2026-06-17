public class CourseWithStudentsDto
{
    public string CourseTitle { get; set; }
    public IEnumerable<Student> Students { get; set; }
}