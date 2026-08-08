using ECommerce.Core.Interfaces;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace ECommerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id) =>
                await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await query.FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;


        public void Update(T entity) => _dbSet.Update(entity);

    }
}
