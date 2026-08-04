using API.Data;
using API.Data.Models;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
