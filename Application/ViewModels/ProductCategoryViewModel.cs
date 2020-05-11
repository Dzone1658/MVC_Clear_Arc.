using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Application.ViewModels
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