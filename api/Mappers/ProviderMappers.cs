using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Provider;
using api.Models;

namespace api.Mappers
{
    public static class ProviderMappers
    {
        public static Provider ToProviderFromCreateDTO(this ProviderAERequestDto providerDto)
        {
            return new Provider
            {
                Name = providerDto.Name,
                Contact = providerDto.Contact,
                Status = providerDto.Status
            };
        }
    }
}