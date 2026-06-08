public class PaypalPayment : IPaymentMethod
{
    
    public void Pay(double amount)
    {
        
        Console.WriteLine($"Paying {amount} using Paypal Payment...");

    }
}