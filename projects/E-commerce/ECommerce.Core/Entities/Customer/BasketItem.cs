namespace ECommerce.Core.Entities.Basket
{
    public class BasketItem
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public string Category { set; get; }
    }
}