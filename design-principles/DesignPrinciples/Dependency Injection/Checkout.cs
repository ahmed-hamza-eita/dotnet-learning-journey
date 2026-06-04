public class Checkout
{
    private readonly IPayment payment;
    public Checkout(IPayment payment)
    {
        this.payment=payment;

    }

    public void CompleteOrder()
    {
        payment.Pay();
    }

}