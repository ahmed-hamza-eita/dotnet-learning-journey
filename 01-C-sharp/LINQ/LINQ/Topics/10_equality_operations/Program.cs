Console.WriteLine(" Equality Operations......");



/*SequenceEqual -> It returns true if both sequences contain
                the exact same number of elements,
                the same values,
                and in the exact same order 
                otherwise, it returns false
                 */
var list1 = new List<int>() { 1, 2, 3, 4 };
var list2 = new List<int>() { 1, 2, 4, 5 };

var sequenceEqual = list1.SequenceEqual(list2);
Console.WriteLine($"List 1 and List 2  {(sequenceEqual ? "are" : "are not")} Equal");




