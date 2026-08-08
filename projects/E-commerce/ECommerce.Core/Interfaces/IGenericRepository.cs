using System.Linq.Expressions;

namespace ECommerce.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
    }
}
