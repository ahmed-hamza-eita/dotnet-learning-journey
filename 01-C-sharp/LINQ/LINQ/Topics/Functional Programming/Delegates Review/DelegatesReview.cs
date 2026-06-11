class DelegatesReview
{
    //public delegate void MyDel();
    //Instead of declaring a custom delegate, use the built-in delegates:

    public delegate Action MyDel();
    public static void M1()
    {
        Console.WriteLine("M1");
    }


    public static void M2(MyDel myDel)
    {
        myDel();
        Console.WriteLine("M2");
    }
}