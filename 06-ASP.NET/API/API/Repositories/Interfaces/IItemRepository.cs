using API.Data.Models;

namespace API.Repositories.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<bool> ExistsAsync(string name, decimal price, string note, byte[] image, int categoryId);

        Task<IEnumerable<Item?>> GetItemsWithCategory(int categoryId);
    }
}
