using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_EF_CodeFirst.Models
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

        public Category ProductCategory { get; set; }
    }
}