class Pizza()
{
   protected virtual string Title => nameof(Pizza);

    protected virtual decimal Price => 5.00m;

    private static Pizza MakeOrder(string type)
    {

        Pizza pizza;
        if (type.Equals(ConstPizza.CheesePizza))
        {

            pizza = new CheesePizza();
        }
        else if (type.Equals(ConstPizza.MeatPizza))
        {
           pizza = new MeatPizza(); 
        }
        else
        {

            pizza = new ChickenPizza();
        }


        return pizza;
    }



    public static Pizza RequestOrder(string type)
    {

        Pizza pizza = MakeOrder(type);
        Perpare();
        Cock();
        Boxing();
        return pizza;
    }
 

    private static void Perpare()
    {
        Console.Write("Preparing the pizza...");
        Thread.Sleep(500);
        Console.Write("Completed...");

    }

    private static void Cock()
    {
        Console.Write("Cocking the pizza...");
        Thread.Sleep(500);
        Console.Write("Completed...");

    }
    private static void Boxing()
    {
        Console.Write("Cutting and Boxing the pizza...");
        Thread.Sleep(500);
        Console.Write("Completed...");

    }

    public override string ToString()
    {
        return $"Title: {Title},\n \t Price: {Price:C}";
    }
}