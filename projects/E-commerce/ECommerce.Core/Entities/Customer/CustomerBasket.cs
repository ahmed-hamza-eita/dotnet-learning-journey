namespace ECommerce.Core.Entities.Basket
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {

        }
        public CustomerBasket(int id)
        {
            Id = id;
        }
        public int Id { set; get; }
        public List<BasketItem> BasketItems { set; get; } = new List<BasketItem>();
    }
}
