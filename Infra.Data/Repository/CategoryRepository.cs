using System.Collections.Generic;
using System.Linq;
using System.Net;
using Domain.Interfaces;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EfDbContext _efDbContext;

        public CategoryRepository(EfDbContext efDbContext)
        {
            _efDbContext = efDbContext;
        }

        public List<Category> GetCategories()
        {
            var list = _efDbContext.Categories.ToList( );
            return list;
        }

        public int AddCategory(Category category)
        {
            _efDbContext.Categories.Add( category );
            var result = _efDbContext.SaveChanges( );
            return result;
        }

        public Category GetCategoryById(int? id)
        {
            var result = _efDbContext.Categories.Find( id );
            return result;
        }

        public int EditCategory(Category category)
        {
            if ( category != null )
            {
                Category model = _efDbContext.Categories.Find( category.CategoryId );
                model.CategoryName = category.CategoryName;
                var result = _efDbContext.SaveChanges( );
                return result;
            }
            return 0;
        }

        public int DeleteCategory(int? id)
        {
            var getResult = _efDbContext.Categories.Find( id );
            if ( getResult != null )
            {
                _efDbContext.Categories.Remove( getResult );
                var result = _efDbContext.SaveChanges( );
                return result;
            }
            return 0;
        }
    }
}
