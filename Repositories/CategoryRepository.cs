using System;
using System.Collections.Generic;
using System.Linq;
using News.Models;

namespace News.Repositories
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private readonly NewsContext _newsContext;

        public CategoryRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public Category GetCategoryById(uint categoryId)
        {
            return _newsContext.Category.Find(categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return _newsContext.Category.ToList();
        }

        public void AddCategory(Category category)
        {
            _newsContext.Category.Add(category);
            _newsContext.SaveChanges();
        }

        // TODO: （重构）类别改为“未分类”
        public void DeleteCategoryById(uint categoryId)
        {
            var articles = _newsContext.Article
                .Where(a => a.CategoryId == categoryId)
                .ToList();
            foreach (var article in articles)
            {
                article.CategoryId = 0;
            }

            _newsContext.Category.Remove(new Category()
            {
                Id = categoryId
            });
            _newsContext.SaveChanges();
        }

        public void Dispose()
        {
            _newsContext?.Dispose();
        }
    }
}