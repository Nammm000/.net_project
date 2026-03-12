using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Bill;

public class CreateBillItemRequest
{
    public long ProductId { get; set; }

    public decimal price { get; set; }

    public int Quantity { get; set; }
}