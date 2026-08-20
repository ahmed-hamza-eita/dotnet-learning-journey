
using ECommerce.Core.Entities.Basket;
using ECommerce.Core.Interfaces;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System.Text.Json;

namespace ECommerce.Infrastructure.Repositories
{
    public class CustomerBasketRepository : ICustomerBasketRepository
    {
        private readonly StackExchange.Redis.IDatabase _database;
        public CustomerBasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<CustomerBasket?> GetBasketAsync(string id)
        {
            var result = await _database.StringGetAsync(id);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonSerializer.Deserialize<CustomerBasket>(result.ToString());
            }
            return null;
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            var result = await _database.StringSetAsync
                (basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(3));

            if (result)
            {
                return await GetBasketAsync(basket.Id);
            }
            return null;
        }
        public Task<bool> DeleteBasket(string id) => _database.KeyDeleteAsync(id);

    }
}
