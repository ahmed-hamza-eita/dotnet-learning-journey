using Microsoft.EntityFrameworkCore;
using Task_1.Data;
using Task_1.Repositories.Interfaces;

namespace Task_1.Repositories.Implementation
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


        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();


        public async Task<T?> GetByIdAsyns(int Id) => await _dbSet.FindAsync(Id);


        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

        public void Update(T entity) => _dbSet.Update(entity);


    }
}
