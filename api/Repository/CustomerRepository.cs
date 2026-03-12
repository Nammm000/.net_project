using api.Data;
using api.Dtos.Customer;
using api.Models;
using api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context;

        public CustomerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            return await _context.Customers
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Username = c.Username,
                    ContactNumber = c.ContactNumber,
                    Address = c.Address
                })
                .ToListAsync();
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(long id)
        {
            return await _context.Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Username = c.Username,
                    Address = c.Address
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<CustomerDto>> GetAllContactNumbersAsync()
        {
            return await _context.Customers
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    ContactNumber = c.ContactNumber
                })
                .ToListAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> UpdateAsync(long id, CustomerAERequestDto customerDto)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return null;
            }

            customer.Username = customerDto.Username;
            customer.ContactNumber = customerDto.ContactNumber;
            customer.Address = customerDto.Address;

            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteAsync(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return null;
            }
            else
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
        }
    }
}