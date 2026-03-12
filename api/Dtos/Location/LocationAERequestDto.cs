using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Location
{
    public class LocationAERequestDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Title cannot be over 20 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}