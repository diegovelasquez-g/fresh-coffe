using AutoMapper;
using CFS.DAL.Models;
using CFS.DTO.Request;

namespace CFS.DTO.Mappers;

public class UserMappingsProfile : Profile
{
    public UserMappingsProfile()
    {
        CreateMap<User, NewUserRequestDto>().ReverseMap();
    }
}