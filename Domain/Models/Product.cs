using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            ProductCategory = new Category();
        }

        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public virtual Category ProductCategory { get; set; }

    }
}