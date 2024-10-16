public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity, Guid? userId = null);
    Task UpdateAsync(T entity, Guid? userId = null);
    Task DeleteAsync(Guid id, Guid? userId = null);
}