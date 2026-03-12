using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Bill;

public class CreateBillRequest
{
    public string Name { get; set; }

    public string Uuid { get; set; }

    public string ContactNumber { get; set; }

    public string PaymentMethod { get; set; }

    public string CreatedBy { get; set; }

    public List<CreateBillItemRequest> Items { get; set; }
}