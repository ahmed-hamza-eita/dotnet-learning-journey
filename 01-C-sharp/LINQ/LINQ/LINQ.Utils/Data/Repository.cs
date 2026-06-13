
public static class Repository
{

    public static IEnumerable<Employee> LoadEmployees()
    {
        return new List<Employee>
            {
            new Employee
                {
                        Id = 1001,
                        FirstName = "Cochran",
                        LastName = "Cole",
                        Email = "Cole.Cochran@example.com",
                        Skills = new() {"ASP.NET" , "CSS" , "Oracle"}
                },
                new Employee
                {
                        Id = 1002,
                        FirstName = "Jaclyn",
                        LastName = "Wolfe",
                        Email = "Wolfe.Jaclyn@example.com",
                        Skills = new() {"ASP.NET" , "SQL Server" , "Javascript" , "CSS" , "HTML"}
                },
                new Employee
                {
                        Id = 1003,
                        FirstName = "Warner",
                        LastName = "Jones",
                        Email = "Jones.Warner@example.com",
                        Skills = new() {"HTML" , "Oracle" , "SQL Server"}
                },
                new Employee
                {
                        Id = 1004,
                        FirstName = "Hester",
                        LastName = "Evans",
                        Email = "Evans.Hester@example.com",
                        Skills = new() {"ASP.NET"}
                }
            };
    }
}