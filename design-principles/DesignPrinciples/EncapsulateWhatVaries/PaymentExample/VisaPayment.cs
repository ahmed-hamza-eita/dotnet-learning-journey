public class VisaPayment : IPaymentMethod
{
    
    public void Pay(double amount)
    {
        
        Console.WriteLine($"Paying {amount} using Visa Card...");

    }
}