using api.Models;
using api.Dtos.Location;

namespace api.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocationsAsync();
        Task<Location?> GetByIdAsync(long id);
        Task AddAsync(Location location);
        Task<Location?> UpdateAsync(long id, LocationAERequestDto locationDto);
        Task<Location?> DeleteAsync(long id);
    }
}