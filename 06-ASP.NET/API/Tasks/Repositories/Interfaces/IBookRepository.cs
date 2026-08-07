using Task_1.Models;

namespace Task_1.Repositories.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<bool> ExistsAsync(string title, int authorId, DateOnly publishedDate);
        Task<IEnumerable<Book>> GetAllWithAuthorAsync();
        Task<Book?> GetByIdWithAuthorAsync(int id);

    }
}
