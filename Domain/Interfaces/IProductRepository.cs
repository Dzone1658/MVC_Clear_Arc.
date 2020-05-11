using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductCategory();
    }
}
