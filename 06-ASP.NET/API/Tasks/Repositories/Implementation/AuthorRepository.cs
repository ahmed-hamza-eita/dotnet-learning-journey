using Microsoft.EntityFrameworkCore;
using Task_1.Data;
using Task_1.Repositories.Implementation;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Repositories.Implementation
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
