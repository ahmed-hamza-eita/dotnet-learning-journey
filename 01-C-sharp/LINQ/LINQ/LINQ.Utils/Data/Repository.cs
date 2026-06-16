
public static class Repository
{

        public static IEnumerable<Employee> LoadEmployees()
        {
                return new List<Employee>
            {
                new Employee
                {
                     Index = 1,
                     EmployeeNo = "2017-FI-8516",
                     Name = "Cochran Cole",
                     Email = "Cole.Cochran@example.com",
                     Salary = 103200,
                     Skills = new() {"Javascript" , "NodeJS"  }
                },
                new Employee
                {
                     Index = 2,
                     EmployeeNo = "2018-FI-4815",
                     Name = "Jaclyn Wolfe",
                     Email = "Wolfe.Jaclyn@example.com",
                     Salary = 192400,
                     Skills = new() {"C++" , "Javascript" , "Oracle"  }
                },
                new Employee
                {
                     Index = 3,
                     EmployeeNo = "2016-IT-1329",
                     Name = "Warner Jones",
                     Email = "Jones.Warner@example.com",
                     Salary = 172800,
                     Skills = new() {"NodeJS" , "C++"  }
                },
                new Employee
                {
                     Index = 4,
                     EmployeeNo = "2016-FI-8336",
                     Name = "Hester Evans",
                     Email = "Evans.Hester@example.com",
                     Salary = 155500,
                     Skills = new() {"C++" , "SQL Server"  }
                },
                new Employee
                {
                     Index = 5,
                     EmployeeNo = "2014-IT-3129",
                     Name = "Wallace Buck",
                     Email = "Buck.Wallace@example.com",
                     Salary = 315800,
                     Skills = new() {"HTML" , "ASP.NET" , "NodeJS"  }
                }};
        }
}