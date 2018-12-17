using System;
using System.Collections.Generic;

namespace News.Service
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        void AddCategory(Category category);
        void DeleteCategoryById(int id);
    }
}