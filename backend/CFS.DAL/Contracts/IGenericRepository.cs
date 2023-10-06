namespace CFS.DAL.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task CreateAsync(T entity);
    void UpdateAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}