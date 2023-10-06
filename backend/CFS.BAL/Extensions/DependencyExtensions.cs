using CFS.BAL.Contracts;
using CFS.BAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CFS.BAL.Extensions;

public static class DependencyExtensions
{
    public static IServiceCollection AddInjectionBal(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}