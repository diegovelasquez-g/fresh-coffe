using CFS.DAL.Models;
using CFS.DTO.Request;
using CFS.DTO.Response;

namespace CFS.BAL.Contracts;

public interface IUserService
{
    Task<bool> CreateUserAsync(NewUserRequestDto newNewUser);

    Task<BaseResponse<LoginResponseDto>> LoginAsync(LoginRequestDto userCredentials);

    Task<bool> UpdateUserAsync(int userId, EditUserRequestDto updatedNewUser);

    Task<bool> ChangeUserStatus(int userId);

    Task<List<User>> GetAllUsersAsync();
}