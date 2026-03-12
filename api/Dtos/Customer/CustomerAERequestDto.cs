using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Customer
{
    public class CustomerAERequestDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Title cannot be over 20 characters")]
        public string Username { get; set; }

        // [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be a 10-digit number.")]
        public string? ContactNumber { get; set; }

        // [Required]
        public string? Address { get; set; }
    }
}