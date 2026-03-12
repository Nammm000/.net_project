using api.Data;
using api.Dtos.Provider;
using api.Models;
using api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDBContext _context;

        public ProviderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProviderDto>> GetAllProvider()
        {
            return await _context.Providers
                .Select(p => new ProviderDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    // Email = p.Email,
                    // Phone = p.Phone,
                    Status = p.Status
                })
                .ToListAsync();
        }

        public async Task AddAsync(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
            await _context.SaveChangesAsync();
        }

        public async Task<Provider?> UpdateAsync(long id, ProviderAERequestDto providerAERequestDto)
        {
            var provider = await _context.Providers.FindAsync(id);
            if (provider == null)
            {
                return null;
            }

            provider.Name = providerAERequestDto.Name;

            provider.Status = providerAERequestDto.Status;

            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider?> DeleteAsync(long id)
        {
            var provider = await _context.Providers.FindAsync(id);
            if (provider == null)
            {
                return null;
            }
            else
            {
                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();
                return provider;
            }
        }

        public async Task<Provider?> UpdateProviderStatus(string status, long id)
        {
            var provider = await _context.Providers.FindAsync(id);

            if (provider == null)
                return null;

            provider.Status = status;
            await _context.SaveChangesAsync();

            return provider;
        }
    }
}