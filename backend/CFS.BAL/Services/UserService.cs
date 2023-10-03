using AutoMapper;
using CFS.BAL.Contracts;
using CFS.DAL.Contracts;
using CFS.DAL.Models;
using CFS.DTO.Request;
using CFS.DTO.Response;

namespace CFS.BAL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IPasswordHasherService passwordHasherService, IMapper mapper, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordHasherService = passwordHasherService;
        _mapper = mapper;
        _jwtService = jwtService;
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

    public async Task<BaseResponse<LoginResponseDto>> LoginAsync(LoginRequestDto userCredentials)
    {
        var response = new BaseResponse<LoginResponseDto>();

        var userToAuth = await _userRepository.GetUserByEmailAsync(userCredentials.Email);
        if (userToAuth is null)
        {
            response.IsSuccess = false;
            response.Message = "No se ha encontrado el usuario.";
            return response;
        }

        if (userToAuth.IsActive == false)
        {
            response.IsSuccess = false;
            response.Message = "El usuario no está activo.";
            return response;
        }

        var isPasswordValid = _passwordHasherService.Verify(userToAuth.Password, userCredentials.Password);
        if (!isPasswordValid)
        {
            response.IsSuccess = false;
            response.Message = "Las credenciales no son válidas.";
            return response;
        }

        var loginResponse = _mapper.Map<LoginResponseDto>(userToAuth);
        loginResponse.Token = _jwtService.GenerateToken(userToAuth);
        response.IsSuccess = true;
        response.Data = loginResponse;
        response.Message = "Se ha iniciado sesión.";
        return response;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var usersList = await _userRepository.GetAllUsersAsync();
        return usersList;
    }
}