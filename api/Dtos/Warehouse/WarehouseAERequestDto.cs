using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Warehouse
{
    public class WarehouseAERequestDto
    {

        [Required]
        [MaxLength(20, ErrorMessage = "Title cannot be over 20 characters")]
        public string Name { get; set; }

        [Required]
        public bool? IsRefrigerated { get; set; }

        [Required]
        public bool? Status { get; set; }

        [Required]
        public long LocationId { get; set; }
    }
}