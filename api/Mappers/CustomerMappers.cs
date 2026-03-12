using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Customer;
using api.Models;

namespace api.Mappers
{
    public static class CustomerMappers
    {
        public static Customer ToCustomer(this CustomerDto customerModel)
        {
            return new Customer
            {
                Id = customerModel.Id,
                Username = customerModel.Username,
                ContactNumber = customerModel.ContactNumber,
                Address = customerModel.Address
            };
        }

        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            return new CustomerDto
            {
                Id = customerModel.Id,
                Username = customerModel.Username,
                Address = customerModel.Address
            };
        }
        public static Customer ToCustomerFromCreateDTO(this CustomerAERequestDto customerDto)
        {
            return new Customer
            {
                Username = customerDto.Username,
                ContactNumber = customerDto.ContactNumber,
                Address = customerDto.Address
            };
        }
    }
}