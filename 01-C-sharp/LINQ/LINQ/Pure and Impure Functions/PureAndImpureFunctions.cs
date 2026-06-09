using System.Numerics;

class PureAndImpureFunctions
{

    /* pure -->
               A function that always returns the same output for the same input and has no side effects.
               predictable, easier to test, and safer to use in LINQ and parallel operations.
     */

    public int Add(int a, int b)
    {
        return a + b;
    }

    /* Impure -->
                  A function that either produces different output for the same input, or modifies something outside its scope. 
                  can cause unexpected bugs especially in multi-threaded environments.
    */

    // 1- Modifies external state
    int total = 0;
    public int AddToTotal(int n)
    {
        return total += n;
    }

    // 2- Modifies original value via ref
    public int Increment(ref int n)
    {
        return n + 1;
    }

    //3- Different output each time
    public int GetRandom()
    {
        return new Random().Next(1, 100);
    }

}