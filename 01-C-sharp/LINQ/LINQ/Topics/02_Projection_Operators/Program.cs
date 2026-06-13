using LINQ.Utils;
Console.WriteLine("--- Projection Operators ---");


SelectMethod();
SelectManyMethod();
ZipMethod();

static void SelectMethod()
{
    Console.WriteLine("---------------------Select....");

    List<string> l1 = new List<string> { "asp.net", "core" };

    l1.Select(x => x.ToUpper()).Print("Uppercase Strings");


    List<int> l2 = new List<int> { 6, 5 };
    l2.Select(x => x * x).Print("Square Numbers");

    // Projection Operation:
    // Transform Employee objects into EmployeeDto objects
    // by selecting only the required fields (Name, TotalSkills).
    var employees = Repository.LoadEmployees();
    employees.Select(emp =>
   {
       return new EmployeeDto
       {
           Name = emp.FullName,
           TotalSkills = emp.Skills.Count()
       };
   }).Print("Employee DTOs");

}


static void SelectManyMethod()
{
    Console.WriteLine("---------------------Select Many....");

    var employees = Repository.LoadEmployees();
    employees.SelectMany(x => x.Skills).Distinct().Print("Skills");


}


static void ZipMethod()
{
    Console.WriteLine("---------------------Zip Operation....");

    string[] colorName = { "RED", "Green", "Blue" };
    string[] colorHex = { "FF0000", "00FF00", "0000FF" };

    colorName.Zip(
        colorHex,
        (name, hex) => $"{name} ({hex})"
        ).Print("Zip Operation");


    var employees = Repository.LoadEmployees().ToArray();
    employees[..3].Zip(
        employees[^3..],
        (first, last) => $"{first.FullName} with {last.FullName}"
        ).Print("Employees with ZIP");

}