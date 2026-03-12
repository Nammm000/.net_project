using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("product1")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [ForeignKey("Category")]
        [Column("category_fk")]
        public long CategoryId { get; set; }

        public Category Category { get; set; } = new Category();

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("status")]
        public string Status { get; set; } = string.Empty;
        // Available, OutOfStock, Discontinued
    }
}