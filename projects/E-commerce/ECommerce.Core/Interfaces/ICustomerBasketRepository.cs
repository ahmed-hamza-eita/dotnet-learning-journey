using ECommerce.Core.Entities.Basket;

namespace ECommerce.Core.Interfaces
{
    public interface ICustomerBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string id);
        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasket(string id);
    }
}
