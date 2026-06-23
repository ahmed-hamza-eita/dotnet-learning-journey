public class Employee
{
    public Employee() { }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime HireDate { get; set; }
    public string Gender { get; set; }
    public int DepartmentId { get; set; }
    public bool HasHealthInsurance { get; set; }
    public bool HasPensionPlan { get; set; }
    public decimal Salary { get; set; }
    public List<string> Skills { get; set; } = new();   

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString()
    {
        return $"{Id}\t" +
               $"{LastName ?? "Unknown"}, {(FirstName ?? "Unknown"), -15}\t" +
               $"{HireDate:d}\t" +
               $"{(Gender ?? "N/A"), -10}\t" +
               $"{HasHealthInsurance}\t" +
               $"{HasPensionPlan}\t" +
               $"{Salary:C}\t" +
               $"Skills: [{string.Join(", ", Skills)}]";
    }
}