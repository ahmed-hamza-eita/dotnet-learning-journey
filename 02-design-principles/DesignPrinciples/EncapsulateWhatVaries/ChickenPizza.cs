class ChickenPizza():Pizza
{
    protected override string Title => nameof(ChickenPizza);

    protected override decimal Price => base.Price + 4.00m;
 
}