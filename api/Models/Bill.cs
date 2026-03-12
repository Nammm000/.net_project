using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("bill")]
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Uuid { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string PaymentMethod { get; set; }

        public decimal? Total { get; set; }

        public string CreatedBy { get; set; }

        public string ApprovedBy { get; set; }

        public DateTime? CreatedTime { get; set; } = DateTime.Now;

        public string Status { get; set; } = "pending"; // approved, pending, rejected

        public ICollection<BillItem> BillItems { get; set; }
    }
}