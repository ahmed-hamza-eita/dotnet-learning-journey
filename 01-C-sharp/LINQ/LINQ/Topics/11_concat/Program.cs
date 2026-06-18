using LINQ.Utils;
Console.WriteLine("Concat......");

//concat
var currentEmp = new List<string> { "Ahmed", "Sara", "Ahmed" };
var newHires = new List<string> { "Ali", "Mona" };
var allEmp = currentEmp.Concat(newHires); //Don,t remove duplicate
foreach (var i in allEmp)
{
    Console.Write($"{i}  ");

}

Console.WriteLine("");

//Union
var allEmp2 = currentEmp.Union(newHires); //remove duplicate
foreach (var i in allEmp2)
{
    Console.Write($"{i}  ");

}