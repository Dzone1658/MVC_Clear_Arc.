using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        
        int AddCategory(Category category);
        Category GetCategoryById(int? id);
        
        int EditCategory(Category category);
        int DeleteCategory(int? id);
    }
}
