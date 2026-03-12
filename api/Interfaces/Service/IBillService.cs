using api.Dtos.Bill;
using api.Models;

namespace api.Interfaces.Service;

public interface IBillService
{
    Task<Bill> CreateBillAsync(CreateBillRequest request);
}