using System.Text.RegularExpressions;
using LINQ.Utils;

Console.WriteLine("Data Partitioning.................");

var employees = Repository.LoadEmployees();

#region Skip

employees.Skip(2).Print("Skip First 2 elements");
employees.SkipLast(2).Print("Skip Last 2 elements");
employees.SkipWhile(emp => emp.Index != 2).Print("");

#endregion


#region Take
employees.Take(2).Print("Take First 2 elements");
employees.TakeLast(2).Print("Take Last 2 elements");
employees.TakeWhile(emp => emp.Index != 2).Print("");
#endregion

#region  Chunk
employees.Chunk(2) //Splits the collection into smaller groups .
.Select((chunk, index) => new { Group = chunk, Index = index }) // chunk → the current group, index → the group's position (starting from 0).
.ToList() // Converts the result from an IEnumerable<T> into a List<T>.
.ForEach(c => c.Group.Print($"Group {c.Index + 1}")); // is available on List<T> but not on IEnumerable<T>.
 
#endregion