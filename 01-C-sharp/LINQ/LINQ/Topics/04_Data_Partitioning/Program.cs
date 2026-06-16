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

