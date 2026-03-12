using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("warehouse1")]
    public class Warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        [Column("IsRefrigerated")]
        public bool? IsRefrigerated { get; set; }

        public bool? Status { get; set; }

        [ForeignKey("Location")]
        [Column("location_fk")]
        public long LocationId { get; set; }

        public Location Location { get; set; }
    }
}