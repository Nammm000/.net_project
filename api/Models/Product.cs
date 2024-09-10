using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Products")]
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        // public DateTime CreatedOn { get; set; } = DateTime.Now;
        // public int? StockId { get; set; }
        // public Stock? Stock { get; set; }
        // public string AppUserId { get; set; }
        // public AppUser AppUser { get; set; }
    }
}