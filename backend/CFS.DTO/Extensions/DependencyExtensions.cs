using CFS.DTO.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CFS.DTO.Extensions;

public static class DependencyExtensions
{
    public static IServiceCollection AddInjectionDto(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMappingsProfile));
        return services;
    }
}