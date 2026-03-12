using api.Dtos.Customer;
using api.Models;

namespace api.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto?> GetCustomerByIdAsync(long id);
        Task<List<CustomerDto>> GetAllContactNumbersAsync();

        Task AddAsync(Customer customer);
        Task<Customer?> UpdateAsync(long id, CustomerAERequestDto customerDto);
        Task<Customer?> DeleteAsync(long id);
    }
}