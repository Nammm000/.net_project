using api.Data;
using api.Models;
using api.Dtos.Bill;
using api.Interfaces.Repositories;
using api.Interfaces.Service;
public class BillService : IBillService
{
    private readonly IBillRepository _repository;
    private readonly ApplicationDBContext _context;

    private readonly ICurrentUserService _currentUserService;

    public BillService(IBillRepository repository, ApplicationDBContext context, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<Bill> CreateBillAsync(CreateBillRequest request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        var bill = new Bill
        {
            Uuid = Guid.NewGuid().ToString(),
            Name = request.Name,
            ContactNumber = request.ContactNumber,
            PaymentMethod = request.PaymentMethod,
            CreatedBy = _currentUserService.GetCurrentUsername(),
            CreatedTime = DateTime.Now,
            BillItems = new List<BillItem>()
        };

        if (_currentUserService.IsAdmin())
        {
            bill.ApprovedBy = _currentUserService.GetCurrentUsername();
            bill.Status = "approved";
        }
        else
        {
            bill.Status = "pending";
        }

        decimal total = 0;

        foreach (var item in request.Items)
        {
            // var product = await _repository.GetProductByIdAsync(item.ProductId);

            // if (product == null)
            //     throw new Exception($"Product {item.ProductId} not found");

            // int price = product.Price ?? 0;

            var billItem = new BillItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.price
            };

            total += item.price * item.Quantity;

            bill.BillItems.Add(billItem);
        }

        bill.Total = total;

        await _repository.AddBillAsync(bill);

        await _context.SaveChangesAsync();

        await transaction.CommitAsync();

        return bill;
    }
}