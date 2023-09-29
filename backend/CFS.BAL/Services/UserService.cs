using CFS.BAL.Contracts;
using CFS.DAL.Contracts;
using CFS.DAL.Models;

namespace CFS.BAL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasherService;

    public UserService(IUserRepository userRepository, IPasswordHasherService passwordHasherService)
    {
        _userRepository = userRepository;
        _passwordHasherService = passwordHasherService;
    }

    public async Task<bool> CreateUserAsync(User newUser)
    {
        newUser.CreateDate = DateTime.Now;
        newUser.Password = _passwordHasherService.Hash(newUser.Password);

        var isSuccess = await _userRepository.CreateUserAsync(newUser);
        return isSuccess;
    }

    public async Task<bool> UpdateUserAsync(int userId,User updatedUser)
    {
        var existingUser = await _userRepository.GetUserByIdAsync(userId);
        if (existingUser == null)
            return false;

        existingUser.UserName = updatedUser.UserName;
        existingUser.Email = updatedUser.Email;
        //existingUser.RoleId = updatedUser.RoleId; Todo: Revisarlo
        existingUser.UpdateBy = updatedUser.UpdateBy;
        existingUser.UpdateDate = DateTime.Now;

        var isSuccess = await _userRepository.UpdateUserAsync(existingUser);
        return isSuccess;
    }

    public async Task<bool> ChangeUserStatus(int userId)
    {
        var existingUser = await _userRepository.GetUserByIdAsync(userId);
        if (existingUser == null)
            return false;

        existingUser.IsActive = !existingUser.IsActive;
        existingUser.UpdateDate = DateTime.Now;
        
        var isSuccess = await _userRepository.UpdateUserAsync(existingUser);
        return isSuccess;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var userToAuth = await _userRepository.GetUserByEmailAsync(email);
        if (userToAuth is null)
            return false;

        var isPasswordValid = _passwordHasherService.Verify(userToAuth.Password, password);
        return isPasswordValid;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var usersList = await _userRepository.GetAllUsersAsync();
        return usersList;
    }
}