public static class ExtensionFunctional
{
    public static IEnumerable<Employee> Filter
    (IEnumerable<Employee> dataSource, Func<Employee, bool> predicate)

    {
        foreach (var employee in dataSource)
        {
            if (predicate(employee))
            {
                yield return employee;
            }
        }

    }


    public static void Print<T>(this IEnumerable<T> source, string title)
    {
        if (source == null)
            return;
        Console.WriteLine();
        Console.WriteLine("┌───────────────────────────────────────────────────────┐");
        Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
        Console.WriteLine("└───────────────────────────────────────────────────────┘");
        Console.WriteLine();
        foreach (var item in source)
            Console.WriteLine(item);
    }

    public static void RunExtensionFunctional()
    {
        var list = Repository.LoadEmployees();

        var q1 = ExtensionFunctional.Filter(list, emp => emp.FirstName.ToLowerInvariant() == "ma");
        q1.Print("");

        var q2=ExtensionFunctional.Filter(list,emp=>emp.LastName.ToLowerInvariant().StartsWith("ju"));
        q2.Print("");
    }




}