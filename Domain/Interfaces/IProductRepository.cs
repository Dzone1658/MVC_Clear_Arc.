using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProduct();
        Product GetProductCategory();
    }
}
