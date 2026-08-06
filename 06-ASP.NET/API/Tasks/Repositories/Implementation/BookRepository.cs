using Microsoft.EntityFrameworkCore;
using Task_1.Data;
using Task_1.Models;
using Task_1.Repositories.Interfaces;

namespace Task_1.Repositories.Implementation
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string title, string author, DateOnly publishedDate)
            => await _context.Books.AnyAsync(book =>
            book.Title == title &&
            book.Author == author &&
            book.PublishedDate == publishedDate
            );

    }
}
