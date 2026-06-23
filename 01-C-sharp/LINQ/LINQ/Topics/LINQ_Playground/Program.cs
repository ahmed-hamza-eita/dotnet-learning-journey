using System.Text.RegularExpressions;
using LINQ.Utils;

var employees = Repository.LoadEmployees();
var departments = Repository.LoadDepartment();


#region Filtering -> Where
/* Filtering — Where -> Returns only the elements that satisfy a given condition
                       Deferred Execution  */
var highSalary = employees.Where(emp => emp.Salary > 50000);
#endregion

#region Projection -> Select, SelectMany, Zip
// Transforms the shape of the data from one type to another .

//Select -> Returns the (same) number of elements, but in a new shape.
var dtos = employees.Select(e => new EmployeeDto
{
    FullName = e.FullName,
    Department = departments.First(d => d.Id == e.DepartmentId).Name
});

dtos
   .Select(x => $"{x.FullName} - {x.Department}")
   .Print("Dtos");



//SelectMany**-> Flattens nested collections into a single flat collection.
var allSkills = employees.SelectMany(e => e.Skills).Distinct();
var employeeWithItsSkill = employees.SelectMany(
        e => e.Skills,
        (emp, skill) => new
        {
            emp.FullName,
            Skill = skill
        });



//Zip-> Merges two sequences element-by-element based on position (index). 
var names = new List<string> { "Ahmed", "Sara", "Ali" };
var ages = new List<int> { 25, 30, 28 };
var zipped = names.Zip(ages, (name, age) => $"{name} is {age} years old");
zipped.Select(x => x).Print("Zip");

#endregion

#region Sorting -> OrderBy, Comparer
//support multi-level sorting.
var multiSort = employees.OrderBy(e => e.DepartmentId) //default is ASC
                         .ThenByDescending(e => e.Salary);
//Reverse order
var reverseOrder = employees.OrderBy(e => e.Salary).Reverse();
multiSort.Select(s => s).Print("Order by");

//---Custom Comparer** -> Used when the default ordering isn't enough (e.g., custom business logic) .
var levels = new List<string> { "Senior", "Junior", "Mid", "Senior", "Junior" };
var orderLvl = levels.OrderBy(l => l, new LevelComparer());

// OR  need to reuse the same sorting logic in multiple places without duplicating the lambda.
var sortInService = employees.OrderBy(e => e, new EmployeeComparer());
var sortInController = employees.OrderBy(e => e, new EmployeeComparer());

#endregion

#region  Data Partitioning -> Skip, Take, Chunk
//Extracts or splits a portion of a collection — the foundation of any Pagination system.

//1- Skip and Take
var firstThree = employees.Take(3);
var afterThree = employees.Skip(3);

//SkipWhile and TakeWhile** -> Work based on a condition rather than a fixed number — stops as soon as the condition becomes false.
//Take the low Earners  while salary is below 200000 
var lowEarners = employees.OrderBy(e => e.Salary).TakeWhile(e => e.Salary < 200000);
lowEarners.Select(x => x).Print("lowEarners");

//2- Chunk ->Splits the collection into groups of a fixed maximum size.
var empGroups = employees.Chunk(3); //Split all Employee into 3 froups

#endregion

#region Quantifiers -> Any, All, Contains

//Any ->Returns true if at least one element satisfies the condition.
var hasAnyEmps = employees.Any(); // Have any elements?
var hasHighEarner = employees.Any(e => e.Salary > 200000);

//All-> Returns true only if every element satisfies the condition.
var allHasInsurance = employees.All(e => e.HasHealthInsurance);

//Contains ->Checks if a specific value exists in the collection.
var hasDept2 = employees.Select(e => e.DepartmentId).Contains(2);

#endregion

#region Grouping -> GroupBy, ToLookup ->Groups elements together based on a key.

//GroupBy -> deferred
var groupedByDept = employees.GroupBy(e => e.DepartmentId);

//GroupBy with Aggregation
var summary = employees
    .GroupBy(e => e.DepartmentId)
    .Select(group => new
    {
        DepartmentId = group.Key,
        NumberOfEmployees = group.Count(),
        AverageSalary = group.Average(e => e.Salary),
        TotalSalary = group.Sum(e => e.Salary)
    });

foreach (var i in summary)
{
    Console.WriteLine(i);
}

//ToLookup ->Same as GroupBy, but executes immediately, returns a structure you can access directly by key.
var lookup = employees.ToLookup(e => e.DepartmentId);
var itsEmps = lookup[2]; //Direct access to a specific group without iterating all groups
Console.WriteLine(itsEmps);
var keyNotFount = lookup[101]; //returns empty IEnumerable, not null or Exception
Console.WriteLine(keyNotFount);

#endregion

#region Join** ->Join, GroupJoin -> Combines two collections based on a shared key

//Join (INNER JOIN)
var Joining = employees.Join(departments,  //sharedKey is departmentId
    emp => emp.DepartmentId,  //from employee side
    dept => dept.Id,          //from dept side
    (emp, dept) => new
    {
        emp.FullName,
        DepartmentName = dept.Name
    });


//GroupJoin*** ->Every element from the outer source remains in the result — even with no matches — and gets a collection instead of a single value.
var groupJoin = departments.GroupJoin(employees,
    dept => dept.Id,
    emp => emp.DepartmentId,
    (dept, emps) => new
    {
        dept.Name,
        Employees = emps
    });

foreach (var dept in groupJoin)
{
    Console.WriteLine($"\n{dept.Name}:");
    foreach (var emp in dept.Employees)
        Console.WriteLine($"  - {emp.FullName}");
}

#endregion

#region Generation Operators -> Range, Repeat, Empty
// Range — sequential numbers
var rangeNum = Enumerable.Range(1, 6);
// Repeat — repeat the same value a fixed number of times
var reaptedStr = Enumerable.Repeat("Ahmed", 6);
// Empty — a safe empty sequence, better than null
var emptySequende = Enumerable.Empty<String>(); //eliminating the need for null-checks 

#endregion

#region Element Operators -> ElementAt, First, Last, Single -> Returns a single element from the collection based on position or a condition.
//ElementAt->
var elementAt = employees.ElementAt(2);  // element at index 2
var elementAtOrDefault = employees.ElementAtOrDefault(99);  // null if index out of range

//First
var first = employees.First();     // first element, Exception if empty
var firstOrDefault = employees.FirstOrDefault();   // first element, null if empty

//single 
var single = employees.Single(e => e.Id == 1001);  // exactly one match, Exception if zero or more than one
var single2 = employees.SingleOrDefault(e => e.Id == 1001);  // exactly one match, Exception if more than one, null if not found

#endregion

#region  Equality Operators — SequenceEqual -> Compares two collections element-by-element in the same order, returning true only if they are identical.
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 1, 2, 3 };
list1.SequenceEqual(list2);
/* 
(==) -> compares references (are they the same object in memory?)
(SequenceEqual) -> compares actual content element-by-element in order — even if they are two different objects in memory.
*/


//CustomComparer****
#endregion

#region Concat- Union
var currentEmployees = new List<string> { "Ahmed", "Sara" };
var newHires = new List<string> { "Sara", "Ali" };

//concat ->Merges two sequences into one (without) removing duplicates.
var allConcatEmps = currentEmployees.Concat(newHires); // [Ahmed, Sara, Sara, Ali]

//Union ->Merges two sequences into one (with) removing duplicates.
var allUnionEmps = currentEmployees.Union(newHires); // [Ahmed, Sara, Ali]

#endregion

#region Aggregation-> Aggregate and Standard Aggregates
//Standard Aggregates
employees.Count();                          // total count
employees.Count(e => e.Salary > 200000);    // count with condition
employees.Sum(e => e.Salary);                // total sum
employees.Average(e => e.Salary);            // average
employees.Max(e => e.Salary);                // highest value
employees.Min(e => e.Salary);                //lowest salary

//Aggregate***->Builds a custom accumulation operation
var numbers = new List<int> { 1, 2, 3, 4 };
// Without seed — starts from the first element
var sumWithoutSeed = numbers.Aggregate((acc, n) => acc + n);  // acc=1 n=2 =>3 | acc=3 n =3 =>6 | acc=6 n=4 => 10

// With seed — starts from a specified value
var sumWithSeed = numbers.Aggregate(100, (acc, n) => acc + n);  // acc=100 n=1 =>101 | acc=101 n =2 =>103 | acc=103 n=3 => 106 | acc=106 n=4 =>110

//combine full names into one string
var fullEmpsName = employees.Select(e => e.FullName).Aggregate((a, b) => $"{a} , {b}");

//Running balance based on transaction type (deposit/withdraw)
var transactions = new List<(string Type, decimal Amount)>
{
    ("deposit",  5000),
    ("withdraw", 1200),
    ("deposit",  3000),
    ("withdraw", 800),
    ("deposit",  1500),
    ("withdraw", 2000),
};
var finalBalance = transactions.Aggregate(0m,
    (balance, transaction) => transaction.Type == "deposit"
    ? balance + transaction.Amount
    : balance - transaction.Amount);

//Find the highest paid employee using Aggregate (instead of Max)
var highestPaid = employees.Aggregate((current, next) => current.Salary > next.Salary ? current : next);
Console.WriteLine($"\nHighest Paid: {highestPaid.FullName} - {highestPaid.Salary:C}");

//Build department summary string***
var deptSummary = employees.GroupBy(e => e.DepartmentId)
    .Aggregate(
        "",
        (result, group) => result + $"Dept {group.Key} Has {group.Count()} Employees |"
);
Console.WriteLine($"\nSummary: {deptSummary}");

#endregion

#region Set Operators -> Distinct, Except, Intersect
var s1 = new List<int> { 1, 2, 3 };
var s2 = new List<int> { 2, 3, 4 };

// Distinct — remove duplicates from a single collection
var uniqueDeptIds = employees.Select(e => e.DepartmentId).Distinct();

// Except — elements in first but NOT in second
s1.Except(s2); // 1
// Intersect — elements present in BOTH (common elements)
s1.Intersect(s2); //2 ,3
// Union — merge without duplicates
s1.Union(s2); //1 2 3  4

//With Custom Comparer//
// Remove duplicate employees based on Department only, not the full object
var distinctByDept = employees.Distinct(new CustomComparer<Employee, int>(e => e.DepartmentId));

#endregion

#region Converting Data Types

//Cast vs OfType
ArrayList mixedList = new ArrayList { 1, 2, "three", 4 };
var cast = mixedList.Cast<int>(); //throw Exception on "three" 
var ofType = mixedList.OfType<int>(); // skippes "three' (safely)

//ToArray vs ToList vs ToDictionary vs ToLookup
var asList = employees.ToList();  //mutable -> can add / remove
var asArray = employees.ToArray(); //Fixed size 

var byId = employees.ToDictionary(e => e.d); // Dictionary<int,Employee> - key must be unique - mutable -element access -> byId[5]
var byDept = employees.ToLookup(e => e.DepartmentId); //such Dictionary but it allows duplicate keys - immutable  
#endregion