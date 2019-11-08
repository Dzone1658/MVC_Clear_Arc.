using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_EF_CodeFirst.Models
{
    public class ProductCategoryViewModel
    {
        public ProductCategoryViewModel()
        {
            ProductCategory = new List<Category>();
        }
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public List<Category> ProductCategory { get; set; }

    }
}