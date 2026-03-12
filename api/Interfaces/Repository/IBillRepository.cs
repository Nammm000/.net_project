using api.Models;

namespace api.Interfaces.Repositories;

public interface IBillRepository
{
    Task AddBillAsync(Bill bill);

    // Task<Product> GetProductByIdAsync(long id);
}