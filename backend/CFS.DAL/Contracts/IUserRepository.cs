using CFS.DAL.Models;

namespace CFS.DAL.Contracts;

public interface IUserRepository
{
    Task<bool> CreateUserAsync(User user);

    Task<User?> GetUserByEmailAsync(string email);

    Task<User?> GetUserByIdAsync(int id);

    Task<bool> UpdateUserAsync(User user);

    Task<List<User>> GetAllUsersAsync();
}