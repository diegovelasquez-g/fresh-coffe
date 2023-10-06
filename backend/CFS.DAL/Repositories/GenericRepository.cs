using CFS.DAL.Contracts;
using CFS.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace CFS.DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly FreshCoffeeContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(FreshCoffeeContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public void UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
}