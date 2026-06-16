using LINQ.Utils;
Console.WriteLine("Quantifiers.....");

var employees = Repository.LoadEmployees();

// Any
var anyResult = employees.Any(emp => emp.Name
                .StartsWith("jac", StringComparison.OrdinalIgnoreCase));
Console.WriteLine($"Any Result: {anyResult}");

// All
var allResult1 = employees.All
                (empEmail => !string.IsNullOrWhiteSpace(empEmail.Email));

var allResult2 = employees.All(empSkills => empSkills.Skills.Any(s => s == "c#"));

Console.WriteLine($"All Result 1: {allResult1} || All Result 2: {allResult2}");

// Contains
var containsResult = employees.Any(emp => emp.Name.Contains("co",StringComparison.OrdinalIgnoreCase));
Console.WriteLine($"Contains Result: {containsResult}");
