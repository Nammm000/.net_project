using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using api.Models;
using api.Dtos.Bill;
using api.Data;

using api.Interfaces.Service;

namespace api.Controllers
{
    [Route("bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBill([FromBody] CreateBillRequest request)
        {
            if (request.Items == null || !request.Items.Any())
                return BadRequest("Bill must contain items.");

            var bill = await _billService.CreateBillAsync(request);

            return Ok(bill);

            // var bill = new Bill
            // {
            //     Uuid = request.Uuid,
            //     Name = request.Name,
            //     ContactNumber = request.ContactNumber,
            //     PaymentMethod = request.PaymentMethod,
            //     CreatedBy = request.CreatedBy,
            //     CreatedTime = DateTime.Now,
            //     ApprovedBy = _currentUserService.GetCurrentUsername(),
            //     BillItems = new List<BillItem>()
            // };

            // if (_currentUserService.IsAdmin())
            // {
            //     bill.Status = "approved";
            // }
            // else
            // {
            //     bill.Status = "pending";
            // }

            // int total = 0;

            // foreach (var item in request.Items)
            // {
            //     var product = await _context.Products
            //         .FirstOrDefaultAsync(p => p.Id == item.ProductId);

            //     if (product == null)
            //         return BadRequest($"Product {item.ProductId} not found.");

            //     int price = product.Price ?? 0;

            //     var billItem = new BillItem
            //     {
            //         ProductId = product.Id,
            //         Quantity = item.Quantity,
            //         Price = price
            //     };

            //     total += price * item.Quantity;

            //     bill.BillItems.Add(billItem);
            // }

            // bill.Total = total;

            // _context.Bills.Add(bill);

            // await _context.SaveChangesAsync();

            // return Ok(bill);
        }
    }
}