using Microsoft.EntityFrameworkCore;
using Task_1.Data;
using Task_1.Models;
using Task_1.Repositories.Interfaces;
using Tasks.Models;

namespace Task_1.Repositories.Implementation
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string title, int authorId, DateOnly publishedDate)
            => await _context.Books.AnyAsync(book =>
            book.Title == title &&
            book.AuthorId == authorId &&
            book.PublishedDate == publishedDate
            );

        public async Task<IEnumerable<Book>> GetAllWithAuthorAsync() =>
            await _context.Books.Include(b => b.Author).ToListAsync();

    }
}
