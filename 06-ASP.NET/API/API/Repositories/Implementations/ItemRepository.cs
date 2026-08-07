using API.Data;
using API.Data.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string name, decimal price, string note, byte[] image, int categoryId)
         => await _context.Items.AnyAsync(i => i.Name == name && i.Price == price && i.Note == note && i.Image == image && i.categoryId == categoryId);

        public async Task<IEnumerable<Item?>> GetItemsWithCategory(int categoryId)
           => await _context.Items.Where(i => i.categoryId == categoryId).ToListAsync();

    }
}
