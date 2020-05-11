using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfDbContext _efDbContext;

        public ProductRepository(EfDbContext efDbContext)
        {
            _efDbContext = efDbContext;
        }

        public List<Product> GetProductCategory()
        {
            var list = _efDbContext.Products.Include( x => x.ProductCategory ).ToList( );
            return list;
        }
    }
}
