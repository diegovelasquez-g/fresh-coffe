using CFS.DAL.Models;

namespace CFS.BAL.Contracts;

public interface IUserService
{
    Task<bool> CreateUserAsync(User newUser);

    Task<bool> LoginAsync(string email, string password);

    Task<bool> UpdateUserAsync(int userId, User updatedUser);

    Task<bool> ChangeUserStatus(int userId);

    Task<List<User>> GetAllUsersAsync();
}