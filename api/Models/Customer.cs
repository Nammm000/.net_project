using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("customer1")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Required]
        public string ContactNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}