using api.Dtos.Warehouse;
using api.Models;

namespace api.Interfaces.Repositories
{
    public interface IWarehouseRepository
    {
        Task<List<WarehouseDto>> GetAllWarehouses();

        Task<List<WarehouseDto>> GetByLocation(long id);

        Task<WarehouseDto?> GetWarehouseById(long id);

        Task<Warehouse?> AddAsync(WarehouseAERequestDto warehouseAERequestDto);

        Task<Warehouse?> UpdateAsync(long id, WarehouseAERequestDto warehouseAERequestDto);

        Task<Warehouse?> DeleteAsync(long id);

        Task<int> UpdateWarehouseStatus(bool status, long id);
    }
}