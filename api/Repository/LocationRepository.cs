using api.Data;
using api.Models;
using api.Dtos.Location;
using api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDBContext _context;

        public LocationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location?> GetByIdAsync(long id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task AddAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
        }

        public async Task<Location?> UpdateAsync(long id, LocationAERequestDto locationDto)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return null;
            }

            location.Name = locationDto.Name;
            location.Address = locationDto.Address;

            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location?> DeleteAsync(long id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return null;
            }
            else
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
                return location;
            }
        }
    }
}