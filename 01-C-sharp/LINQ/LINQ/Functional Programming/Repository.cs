
//fake data
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
                        HireDate = new DateTime(2017, 11, 2),
                        Gender = "male",
                        Department = "FIMAMCE",
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
                        Department = "FIMAMCE",
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
                        Department = "IT",
                        HasHealthInsurance = false,
                        HasPensionPlan = false,
                        Salary = 172800m
                }
};
        }
}
