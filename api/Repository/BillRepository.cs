using api.Data;
using api.Models;
using api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class BillRepository : IBillRepository
{
    private readonly ApplicationDBContext _context;

    public BillRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task AddBillAsync(Bill bill)
    {
        await _context.Bills.AddAsync(bill);
    }

    // public async Task<Product> GetProductByIdAsync(long id)
    // {
    //     return await _context.Products
    //         .FirstOrDefaultAsync(p => p.Id == id);
    // }
}