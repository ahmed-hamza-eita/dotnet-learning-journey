public static class Repository
{
       public static IEnumerable<Employee> LoadEmployees()
        {
            return new List<Employee> 
            {
                new Employee
                {
                        Id = 1001,
                        FirstName = "Coc3an",
                        LastName = "Cole",
                        HireDate = new DateTime(2017, 11, 2),
                        Gender = "male",
                        DepartmentId = 1,
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 103200m
                },
                new Employee
                {
                        Id = 1002,
                        FirstName = "Jaclyn",
                        LastName = "Wolfe",
                        HireDate = new DateTime(2018, 4, 14),
                        Gender = "female",
                        DepartmentId = 1,
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 192400m
                },
                new Employee
                {
                        Id = 1003,
                        FirstName = "Warner",
                        LastName = "Jones",
                        HireDate = new DateTime(2016, 12, 13),
                        Gender = "male",
                        DepartmentId = 2,
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 172800m
                },
                new Employee
                {
                        Id = 1004,
                        FirstName = "Hester",
                        LastName = "Evans",
                        HireDate = new DateTime(2016, 8, 17),
                        Gender = "male",
                        DepartmentId = 1,
                        HasHealthInsurance = true,
                        HasPensionPlan = true,
                        Salary = 155500m
                },
                new Employee
                {
                        Id = 1005,
                        FirstName = "Wallace",
                        LastName = "Buck",
                        HireDate = new DateTime(2014, 5, 12),
                        Gender = "male",
                        DepartmentId = 2,
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 315800m
                },
                new Employee
                {
                        Id = 1006,
                        FirstName = "Acevedo",
                        LastName = "Wall",
                        HireDate = new DateTime(2020, 10, 30),
                        Gender = "male",
                        DepartmentId = 2,
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 343700m
                },
                new Employee
                {
                        Id = 1007,
                        FirstName = "Jacqueline",
                        LastName = "Pickett",
                        HireDate = new DateTime(2021, 2, 17),
                        Gender = "female",
                        DepartmentId = 2,
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 370000m
                },
                new Employee
                {
                        Id = 1008,
                        FirstName = "Oconnor",
                        LastName = "Espinoza",
                        HireDate = new DateTime(2017, 3, 12),
                        Gender = "male",
                        DepartmentId = 3,
                        HasHealthInsurance = true,
                        HasPensionPlan = false,
                        Salary = 155600m
                },
                new Employee
                {
                        Id = 1009,
                        FirstName = "Allie",
                        LastName = "Elliott",
                        HireDate = new DateTime(2020, 4, 20),
                        Gender = "female",
                        DepartmentId = 4,
                        HasHealthInsurance = false,
                        HasPensionPlan = true,
                        Salary = 315400m
                },
                new Employee
                {
                        Id = 1010,
                        FirstName = "Elva",
                        LastName = "Decker",
                        HireDate = new DateTime(2016, 9, 6),
                        Gender = "female",
                        DepartmentId = 3,
                        HasHealthInsurance = true,
                        HasPensionPlan = true,
                        Salary = 345900m
                }};
        }

       public static IEnumerable<Department> LoadDepartment()
        {
            return new List<Department> { 
                new Department { Id = 1, Name = "FINANCE" },
                new Department { Id = 2, Name = "IT" },
                new Department { Id = 3, Name = "HR" },
                new Department { Id = 4, Name = "ACCOUNTING" },
                new Department { Id = 5, Name = "SALES" }
            };
        }
}
