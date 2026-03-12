using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Provider
{
    public class ProviderAERequestDto
    {

        [Required]
        [MaxLength(20, ErrorMessage = "Title cannot be over 20 characters")]
        public string Name { get; set; }

        // [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be a 10-digit number.")]
        public string? Contact { get; set; }

        [Required]
        public string Status { get; set; }
    }
}