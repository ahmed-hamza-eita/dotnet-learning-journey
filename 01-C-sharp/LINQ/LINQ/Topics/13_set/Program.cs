using LINQ.Utils;

Console.WriteLine("--------Set--------");

var employees = Repository.LoadEmployees();
var allMeetings = Repository.LoadMeetings();

#region Distinct 

var numbers = new List<int> { 1, 2, 2, 3, 3, 4 };
var uniqueNumbers = numbers.Distinct().ToList();
foreach (var i in uniqueNumbers)
{
    Console.WriteLine(i);

}



//DistinctBy
var uniqueEmp = employees.DistinctBy(emp => emp.Id);
foreach (var i in uniqueEmp)
{
    Console.WriteLine(i);

}

#endregion
 

#region  Except
var listA = new List<int> { 1, 2, 3, 4 };
var listB = new List<int> { 3, 4, 5, 6 };
var result = listA.Except(listB); //elements in A and not in B
foreach (var i in result)
{
    Console.WriteLine(i);

}


//If you want a list of employees, is not present in the meetings. //ExceptBy
var meetingsId = allMeetings.SelectMany(m => m.Participants).Select(p => p.Id);
var excludedEmps = employees.ExceptBy(meetingsId, e => e.Id);
foreach (var i in excludedEmps)
{
    Console.WriteLine(i);

}

#endregion 


#region  Intersect  -> Find common elements
var lA = new List<int> { 1, 2, 3, 4 };
var lB = new List<int> { 3, 4, 5, 6 };

var intersect = lA.Intersect(lB); //elements in A and B
foreach (var i in intersect)
{
    Console.WriteLine(i);

}

//Intersect By //If you want a list of employees and presents in the meetings. 
var commonEmp = employees.IntersectBy(meetingsId, e => e.Id);
foreach (var i in commonEmp)
{
    Console.WriteLine(i);

}

#endregion


