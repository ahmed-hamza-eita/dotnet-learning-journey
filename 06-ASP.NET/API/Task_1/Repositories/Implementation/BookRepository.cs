using Task_1.Data;
using Task_1.Models;
using Task_1.Repositories.Interfaces;

namespace Task_1.Repositories.Implementation
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
