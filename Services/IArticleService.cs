using System.Collections.Generic;

namespace News.Service
{
    public interface IArticleService
    {
        Article GetArticleById(int id);
        List<Article> GetAllArticles();
        List<Article> GetArticlesByCategoryId(int id);
        List<Article> SearchArticlesByTitle();
        void AddArticle(Article article);
        void DeleteArticleById(int id);
        void UpdateArticleById(int id);
    }
}