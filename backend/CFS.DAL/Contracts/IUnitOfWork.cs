using CFS.DAL.Models;

namespace CFS.DAL.Contracts;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Category> CategoryRepository { get; }

    Task<bool> SaveChangesAsync();
}