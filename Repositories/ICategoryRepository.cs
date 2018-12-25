using System.Collections.Generic;
using News.Models;

namespace News.Repositories
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(uint categoryId);
        List<Category> GetAllCategories();
        void AddCategory(Category category);
        void DeleteCategoryById(uint categoryId);
    }
}