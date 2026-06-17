
public class EmployeeDto
{
    public string Name { get; set; }
    public int TotalSkills { get; set; }
    public string FullName { get; set; }
    public string Department { get; set; }
    public override string ToString()
    {
        return $"{Name}  {FullName} {Department} ({TotalSkills})";
    }
}