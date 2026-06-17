Console.WriteLine("Element Operation.....");

var employees = Repository.LoadEmployees();

//ElementAt
var element = employees.ElementAt(3); ;
var elementAtOrDefault = employees.ElementAtOrDefault(3); //return default value if index invalid
Console.WriteLine($"ElementAt: {element} \n ElementAtOrDefault {elementAtOrDefault}");



//First -> It returns the first element that matches the condition.
var first = employees.First(emp => emp.Salary == 103200); ;
var firstOrDefault = employees.FirstOrDefault(emp => emp.Salary == 10320000); //return default value if invalid expression
Console.WriteLine($"First: {first} \n FirstOrDefault {firstOrDefault}");

//Last -> Returns the last element that matches the condition (reverse first)


//Single -> It returns only one element that matches the condition.
//var single1 = employees.SingleOrDefault(emp => emp.Gender == "male"); //In single the rrsult must one value otherwise exception
var single2 = employees.SingleOrDefault(emp => emp.LastName == "Cole");
Console.WriteLine($" SingleOrDefault {single2}");






