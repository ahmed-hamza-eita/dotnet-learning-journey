class CheesePizza():Pizza
{
    protected override string Title => nameof(CheesePizza);

    protected override decimal Price => base.Price + 2.00m;
 
}