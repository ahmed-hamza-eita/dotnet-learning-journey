using LINQ.Utils;
Console.WriteLine(".......Aggregation......");

var employees = Repository.LoadEmployees();


#region  Aggergate
var numbers = new List<int> { 1, 2, 3 };
var sum = numbers.Aggregate((acc, n) => acc + n);
/* step 1 -> acc = 1  ,   n=2  -> acc+n= 3
   step 2 -> acc = 3  ,   n=3  -> acc+n=6
 */
Console.WriteLine($"Sum using Aggergate: {sum}");
var sum2 = numbers.Aggregate(10, (acc, n) => acc + n); //initial value of sun is 10 
/* step 1 -> acc = 10  ,   n=1  -> acc+n= 11
   step 2 -> acc = 11 ,   n=2  -> acc+n=13
   step 3 -> acc = 13 ,   n=3  -> acc+n=16
 */
Console.WriteLine($"Sum using Aggergate with initial value: {sum2}");


var words = new List<string> { "Ahmed", "Hamza", "Eita" };
var sentence = words.Aggregate((acc, word) => $"{acc} {word}"); // acc + " " word
Console.WriteLine(sentence);



var longestName = employees.Aggregate(
    employees.First(),
    (longest, next) => longest.FullName.Length < next.FullName.Length ? next : longest

);
Console.WriteLine($"Logest Name: {longestName.FullName}");

#endregion


#region  standard Methods
var totalEmployees = employees.Count();
var totalSalary = employees.Sum(e => e.Salary);
var avgSalary = employees.Average(e => e.Salary);
var maxSalary = employees.Max(e => e.Salary);
var minSalary = employees.Min(e => e.Salary);
var topEmployee = employees.OrderByDescending(e => e.Salary).First();

Console.WriteLine($"Total Employees: {totalEmployees}");
Console.WriteLine($"Total Salary: {totalSalary}");
Console.WriteLine($"Average Salary: {avgSalary}");
Console.WriteLine($"Max Salary: {maxSalary}");
Console.WriteLine($"Min Salary: {minSalary}");
Console.WriteLine($"Top Employee with salary: {topEmployee.FullName}");

#endregion