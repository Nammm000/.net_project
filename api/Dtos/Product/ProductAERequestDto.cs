using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Product
{
    public class ProductAERequestDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Title cannot be over 20 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public long CategoryId { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Description cannot be over 200 characters")]
        public string Description { get; set; }

        [Required]
        public int? Price { get; set; }

        [Required]
        public string Status { get; set; }
    }
}