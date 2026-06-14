using LINQ.Utils;
Console.WriteLine("Sorting.....................");


List<string> fruits = new List<string> { "apple", "orange", "mango" };

fruits.OrderBy(f => f.Length).Print("ASC Order");
fruits.OrderByDescending(f => f.Length).Print("DESC Order");


//Comparer
var employees = Repository.LoadEmployees();
employees.OrderBy(emp => emp, new EmployeeComparer()).Print("Employee Comparer");



//Reverse order 
fruits.ToArray().Reverse().Print("Reverse Order");