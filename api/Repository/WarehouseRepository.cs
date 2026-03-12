using api.Data;
using api.Dtos.Warehouse;
using api.Mappers;
using api.Models;
using api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDBContext _context;

        public WarehouseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<WarehouseDto>> GetAllWarehouses()
        {
            return await _context.Warehouses
                .Include(w => w.Location)
                .Select(w => new WarehouseDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    IsRefrigerated = w.IsRefrigerated ?? false,
                    Status = w.Status ?? false,
                    LocationId = w.LocationId,
                    LocationName = w.Location.Name
                })
                .ToListAsync();
        }

        public async Task<List<WarehouseDto>> GetByLocation(long id)
        {
            return await _context.Warehouses
                .Where(w => w.LocationId == id)
                .Include(w => w.Location)
                .Select(w => new WarehouseDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    IsRefrigerated = w.IsRefrigerated ?? false,
                    Status = w.Status ?? false,
                    LocationId = w.LocationId,
                    LocationName = w.Location.Name
                })
                .ToListAsync();
        }

        public async Task<WarehouseDto?> GetWarehouseById(long id)
        {
            return await _context.Warehouses
                .Where(w => w.Id == id)
                .Include(w => w.Location)
                .Select(w => new WarehouseDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    IsRefrigerated = w.IsRefrigerated ?? false,
                    Status = w.Status ?? false,
                    LocationId = w.LocationId,
                    LocationName = w.Location.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Warehouse?> AddAsync(WarehouseAERequestDto warehouseAERequestDto)
        {
            var locationExists = await _context.Locations
                .AnyAsync(l => l.Id == warehouseAERequestDto.LocationId);

            if (!locationExists)
            {
                return null;
            }

            var warehouse = warehouseAERequestDto.ToWarehouseFromCreateDTO();
            await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
            return warehouse;
        }

        public async Task<Warehouse?> UpdateAsync(long id, WarehouseAERequestDto warehouseAERequestDto)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return null;
            }

            warehouse.Name = warehouseAERequestDto.Name;

            warehouse.Status = warehouseAERequestDto.Status;

            await _context.SaveChangesAsync();
            return warehouse;
        }

        public async Task<Warehouse?> DeleteAsync(long id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return null;
            }
            else
            {
                _context.Warehouses.Remove(warehouse);
                await _context.SaveChangesAsync();
                return warehouse;
            }
        }

        public async Task<int> UpdateWarehouseStatus(bool status, long id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);

            if (warehouse == null)
                return 0;

            warehouse.Status = status;

            return await _context.SaveChangesAsync();
        }
    }
}