using API.Data;
using API.Data.Models;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
