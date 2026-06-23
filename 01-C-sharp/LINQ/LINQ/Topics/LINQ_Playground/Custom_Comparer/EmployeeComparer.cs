public class EmployeeComparer : IComparer<Employee>
{
    public int Compare(Employee? e1, Employee? e2)
    {
        if (e1 == null || e2 == null) { return 0; }
        
        var deptComparison = e1.DepartmentId.CompareTo(e2.DepartmentId);
        if (deptComparison != 0) return deptComparison;

        return e1.Salary.CompareTo(e2.Salary);
    }
}