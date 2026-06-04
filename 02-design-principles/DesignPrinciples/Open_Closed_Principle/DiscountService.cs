
#region Before applying the Open/Closed Principle
// Adding 'Gold' and 'VIP' customers requires modifying the existing class, which violates the principle.
public class DiscountServices
{
    public double CalculateDiscount(string customerType, double price)
    {
        if (customerType.Equals("Regular"))
        {
            return price * 0.05;
        }
        else if (customerType.Equals("Premium"))
        {
            return price * 0.10;
        }
        else if (customerType.Equals("Gold"))
        {
            return price * 0.15;

        }

        return 0;
    }


}

#endregion


#region After Applying the  Open/Closed Principle

public interface IDiscount
{
    double CalculateDiscount(double price);

}

public class RegularDiscount : IDiscount
{

    public double CalculateDiscount(double price)
    {
        return price * 0.05;
    }
}
public class PremiumDiscount : IDiscount
{

    public double CalculateDiscount(double price)
    {
        return price * 0.10;
    }
}

public class GoldDiscount : IDiscount
{

    public double CalculateDiscount(double price)
    {
        return price * 0.15;
    }
}
public class DiscountService
{
    private readonly IDiscount discount;
    public DiscountService(IDiscount discount)
    {
        this.discount = discount;
    }
    public double CalculateDiscount(double price)
    {
        return discount.CalculateDiscount(price);

    }

}


#endregion