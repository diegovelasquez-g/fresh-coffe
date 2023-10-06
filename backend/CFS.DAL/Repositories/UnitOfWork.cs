using CFS.DAL.Contracts;
using CFS.DAL.Data;
using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CFS.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FreshCoffeeContext _dbContext;

    public UnitOfWork(FreshCoffeeContext dbContext, IGenericRepository<Category> categoryRepository)
    {
        _dbContext = dbContext;
        CategoryRepository = categoryRepository;
    }

    public IGenericRepository<Category> CategoryRepository { get; }

    public async Task<bool> SaveChangesAsync()
    {
        var recordsAffected = await _dbContext.SaveChangesAsync();
        return recordsAffected > 0;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}