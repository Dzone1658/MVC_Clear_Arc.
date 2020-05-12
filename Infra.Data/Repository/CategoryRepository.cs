using System;
using System.Collections.Generic;
using System.Linq;
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
            int result = 0;
            try
            {
                _efDbContext.Categories.Add( category );
                _efDbContext.SaveChanges( );
            }
            catch ( Exception ex )
            {
                throw ex;
            }
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
                try
                {

                    _efDbContext.Categories.Where( x => x.CategoryName == category.CategoryName ).Select( x => x.CategoryName );
                    var result = _efDbContext.SaveChanges( );
                    return result;
                }
                catch ( Exception ex)
                {

                    throw ex;
                }
            }
            return 0;
        }

        public Category DeleteCategory(int? id)
        {
            var result = _efDbContext.Categories.Find( id );
            if ( result.CategoryId > 0 )
            {
                var removeRecord = _efDbContext.Categories.Remove( result );
                return removeRecord;
            }
            return null;
        }
    }
}
