using AutoMapper;
using CFS.DAL.Models;
using CFS.DTO.Request;
using CFS.DTO.Response;

namespace CFS.DTO.Mappers;

public class UserMappingsProfile : Profile
{
    public UserMappingsProfile()
    {
        CreateMap<User, LoginResponseDto>();
        CreateMap<User, NewUserRequestDto>().ReverseMap();
    }
}