using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Location;
using api.Models;

namespace api.Mappers
{
    public static class LocationMappers
    {
        public static Location ToLocationFromCreateDTO(this LocationAERequestDto locationDto)
        {
            return new Location
            {
                Name = locationDto.Name,
                Address = locationDto.Address
            };
        }
    }
}