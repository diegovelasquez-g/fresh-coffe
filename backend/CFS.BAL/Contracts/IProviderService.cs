using CFS.DAL.Models;

namespace CFS.BAL.Contracts;

public interface IProviderService
{
    Task<bool> CreateProviderAsync(Provider provider);
    Task<bool> UpdateProviderAsync(int providerId, Provider provider);
    Task<bool> ChangeProviderStatus(int providerId);
    Task<Provider?> GetProviderByIdAsync(int id);
    Task<List<Provider>> GetAllProvidersAsync();
}