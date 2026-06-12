
Console.WriteLine("Where Operator...");
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 6, 8, 10 };

var evenNumbersUsingExtensionWhere =
 numbers.Where(num => num % 2 == 0);

var evenNumbersUsingEnumrableWhereMethod =
Enumerable.Where(numbers, num => num % 2 == 0);

var evenNumbersUsingQuerySyntax = from n in numbers
                                  where n % 2 == 0
                                  select n;





var list = new List<int> { 1, 2, 3, 4, 5, 6 };
var result = list.Where(x => x % 2 == 0); // Deferred Execution OR Lazy Excetion

list.Add(5);
list.Add(8);
list.Add(10);

//Immediate Execution   
foreach (var item in result)
{
    Console.WriteLine(item);
}

// LINQ Where() uses Deferred Execution.
// Query execution is delayed until enumeration.
// Therefore, items added to the collection before foreach are included in the result.

Console.ReadKey();
