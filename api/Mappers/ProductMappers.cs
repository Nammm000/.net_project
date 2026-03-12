using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Product;

namespace api.Mappers
{
    public static class ProductMappers
    {
        public static Product ToProductFromCreateDTO(this ProductAERequestDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Status = productDto.Status,
                CategoryId = productDto.CategoryId
            };
        }
    }
}