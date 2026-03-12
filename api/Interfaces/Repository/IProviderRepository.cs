using api.Models;
using api.Dtos.Provider;

namespace api.Interfaces.Repositories
{
    public interface IProviderRepository
    {
        Task<List<ProviderDto>> GetAllProvider();

        Task AddAsync(Provider provider);
        Task<Provider?> UpdateAsync(long id, ProviderAERequestDto providerAERequestDto);
        Task<Provider?> DeleteAsync(long id);

        Task<Provider?> UpdateProviderStatus(string status, long id);
    }
}