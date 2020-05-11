using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();

        int AddCategory(Category category);
        Category GetCategoryById(int? id);
        
        int EditCategory(Category category);
        Category DeleteCategory(int? id);
    }
}
