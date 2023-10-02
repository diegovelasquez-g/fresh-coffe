using AutoMapper;
using CFS.BAL.Contracts;
using CFS.DAL.Contracts;
using CFS.DAL.Models;
using CFS.DTO.Request;

namespace CFS.BAL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IPasswordHasherService passwordHasherService, IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordHasherService = passwordHasherService;
        _mapper = mapper;
    }

    public async Task<bool> CreateUserAsync(NewUserRequestDto newNewUser)
    {
        var user = _mapper.Map<User>(newNewUser);
        user.CreateDate = DateTime.Now;
        user.Password = _passwordHasherService.Hash(user.Password);

        var isSuccess = await _userRepository.CreateUserAsync(user);
        return isSuccess;
    }

    public async Task<bool> UpdateUserAsync(int userId, EditUserRequestDto updatedNewUser)
    {
        var existingUser = await _userRepository.GetUserByIdAsync(userId);
        if (existingUser == null)
            return false;

        if(!string.IsNullOrEmpty(updatedNewUser.UserName))
            existingUser.UserName = updatedNewUser.UserName;

        if (!string.IsNullOrEmpty(updatedNewUser.Email))
            existingUser.Email = updatedNewUser.Email;

        //existingUser.RoleId = updatedNewUser.RoleId; Todo: Revisarlo
        existingUser.UpdateBy = updatedNewUser.UpdateBy;
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

    public async Task<bool> LoginAsync(LoginRequestDto userCredentials)
    {
        var userToAuth = await _userRepository.GetUserByEmailAsync(userCredentials.Email);
        if (userToAuth is null)
            return false;

        var isPasswordValid = _passwordHasherService.Verify(userToAuth.Password, userCredentials.Password);
        return isPasswordValid;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var usersList = await _userRepository.GetAllUsersAsync();
        return usersList;
    }
}