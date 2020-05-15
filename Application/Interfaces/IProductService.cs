using System.Collections.Generic;
using Application.ViewModels;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IProductService
    {
        ProductCategoryViewModel GetProductCategory();
        List<Product> GetProduct();

    }
}
