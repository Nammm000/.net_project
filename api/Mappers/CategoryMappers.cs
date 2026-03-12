using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMappers
    {
        public static Category ToCategoryFromCreateDTO(this Category locationDto)
        {
            return new Category
            {
                Name = locationDto.Name,
                Description = locationDto.Description
            };
        }
    }
}