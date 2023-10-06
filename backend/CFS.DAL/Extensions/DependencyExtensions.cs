using CFS.DAL.Contracts;
using CFS.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CFS.DAL.Extensions;

public static class DependencyExtensions
{
    public static IServiceCollection AddInjectionDal(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}