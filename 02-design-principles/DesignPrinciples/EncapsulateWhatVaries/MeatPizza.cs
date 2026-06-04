class MeatPizza():Pizza
{
    protected override string Title => nameof(MeatPizza);

    protected override decimal Price => base.Price + 3.5m;
 
}