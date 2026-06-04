public class PaymentService
{
    
    private readonly IPaymentMethod paymentMethod;


     public PaymentService(IPaymentMethod paymentMethod)
    {
        this.paymentMethod = paymentMethod;
    }

    public void Pay(double amount)
    {
        paymentMethod.Pay(amount);

    }
}