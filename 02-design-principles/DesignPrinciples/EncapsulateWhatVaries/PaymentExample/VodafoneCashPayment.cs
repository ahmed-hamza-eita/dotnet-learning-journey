public class VodafoneCashPayment : IPaymentMethod
{
    
    public void Pay(double amount)
    {
        
        Console.WriteLine($"Paying {amount} using Vodafone Cash...");

    }
}