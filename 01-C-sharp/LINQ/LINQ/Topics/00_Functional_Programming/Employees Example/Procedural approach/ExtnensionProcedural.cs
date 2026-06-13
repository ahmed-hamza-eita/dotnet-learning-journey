public static class ExtnensionProcedural
{
    public static IEnumerable<Employee> GetEmployeesWithFirstNameStartsWith(string value)
    {
        var employees = EmployeeRepository.LoadEmployees();
        foreach (var employee in employees)
        {
            if (employee.FirstName.ToLowerInvariant().StartsWith(value.ToLowerInvariant()))
            {
                yield return employee;
            }
        }
    }


    public static IEnumerable<Employee> GetEmployeesWithFirstNameEndsWith(string value)
    {
        var employees = EmployeeRepository.LoadEmployees();
        foreach (var employee in employees)
        {
            if (employee.FirstName.ToLowerInvariant().EndsWith(value.ToLowerInvariant()))
            {
                yield return employee;
            }
        }
    }

    public static IEnumerable<Employee> GetEmployeesWithLastNameStartsWith(string value)
    {
        var employees = EmployeeRepository.LoadEmployees();
        foreach (var employee in employees)
        {
            if (employee.LastName.ToLowerInvariant().StartsWith(value.ToLowerInvariant()))
            {
                yield return employee;
            }
        }
    }
    public static IEnumerable<Employee> GetEmployeesWithSalaryLessThan(decimal value)
    {
        var employees = EmployeeRepository.LoadEmployees();
        foreach (var employee in employees)
        {
            if (employee.Salary < value)
            {
                yield return employee;
            }
        }
    }

    public static void Print<T>(IEnumerable<T> source, string title)
    {
        if (source == null)
            return;
        Console.WriteLine();
        Console.WriteLine("┌───────────────────────────────────────────────────────┐");
        Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
        Console.WriteLine("└───────────────────────────────────────────────────────┘");
        Console.WriteLine();
        foreach (var item in source)
            Console.WriteLine(item);
    }



    public static void RunExtensionProcedural()
    {
        var q1 = ExtnensionProcedural.GetEmployeesWithFirstNameStartsWith("ma");
        ExtnensionProcedural.Print(q1, "Employees with first name starts with 'ma'");

        var q2 = ExtnensionProcedural.GetEmployeesWithLastNameStartsWith("ju");
        ExtnensionProcedural.Print(q2, "Employees with last name starts with 'ju'");

        var q10 = ExtnensionProcedural.GetEmployeesWithSalaryLessThan(107000);
        ExtnensionProcedural.Print(q10, "Employees with Salary < $107000");

    }

}

