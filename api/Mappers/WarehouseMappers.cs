using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Warehouse;

namespace api.Mappers
{
    public static class WarehouseMappers
    {
        public static Warehouse ToWarehouseFromCreateDTO(this WarehouseAERequestDto warehouseDto)
        {
            return new Warehouse
            {
                Name = warehouseDto.Name,
                IsRefrigerated = warehouseDto.IsRefrigerated,
                Status = warehouseDto.Status,
                LocationId = warehouseDto.LocationId
            };
        }
    }
}