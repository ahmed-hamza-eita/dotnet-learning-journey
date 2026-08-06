namespace Task_1.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T: class 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsyns(int Id);
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<bool> SaveChangesAsync();
    }
}
