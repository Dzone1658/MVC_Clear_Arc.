using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            var list = _categoryRepository.GetCategories( );
            return list;
        }

        public int AddCategory (Category category)
        {
            var result = _categoryRepository.AddCategory( category );
            return result;
        }

        public Category GetCategoryById(int? id)
        {
            var result = _categoryRepository.GetCategoryById( id );
            return result;
        }

        public int EditCategory(Category category)
        {
            var result = _categoryRepository.EditCategory( category );
            return result;
        }

        public int DeleteCategory(int? id)
        {
            var result = _categoryRepository.DeleteCategory( id );
            return result;
        }
    }
}
