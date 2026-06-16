using LINQ.Utils;

Console.WriteLine(" Grouping Operations.....");

var employees = Repository.LoadEmployees();


//Group By (Deferred (Lazy) Excution)
var groupedEmployees = employees.GroupBy(emp => emp.Department);
foreach (var group in groupedEmployees)
{
    group.Print($"Employees in {group.Key} With GroupBy ");
}


//ToLookup (Immediate Excution)
var lookupEmployees = employees.ToLookup(emp => emp.Department);
foreach (var lookup in lookupEmployees)
{
    lookup.Print($"Employees in {lookup.Key} With Lookup");
}