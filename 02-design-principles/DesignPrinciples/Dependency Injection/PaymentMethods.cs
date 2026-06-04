public class Visa : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Paid using Visa");

    }
}

public class PayPal : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Paid using PayPal");

    }
}

public class VodafoneCash : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Paid using Vodafone Cash");

    }
}