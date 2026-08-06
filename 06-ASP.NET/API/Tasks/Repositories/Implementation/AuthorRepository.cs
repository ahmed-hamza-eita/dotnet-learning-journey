using Task_1.Data;
using Task_1.Repositories.Implementation;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Repositories.Implementation
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
