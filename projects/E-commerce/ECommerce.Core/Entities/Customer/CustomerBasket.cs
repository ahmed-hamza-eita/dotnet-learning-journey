namespace ECommerce.Core.Entities.Basket
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {

        }
        public CustomerBasket(string id)
        {
            Id = id;
        }
        public string Id { set; get; }
        public List<BasketItem> BasketItems { set; get; } = new List<BasketItem>();
    }
}
