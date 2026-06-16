public class Employee
{
    public int Index { get; set; }
    public string EmployeeNo { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
    public decimal Salary { get; set; }

    public List<string> Skills { get; set; } = new List<string>();
}


