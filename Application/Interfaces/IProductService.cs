using System.Collections.Generic;
using Application.ViewModels;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IProductService
    {
        //List<ProductCategoryViewModel> GetProductCategory();
        List<Product> GetProductCategory();
    }
}
