using System.Collections.Generic;
using News.Models;

namespace News.Repositories
{
    public interface IArticleRepository
    {
        Article GetArticleById(uint id);
        List<Article> GetAllArticles();
        Article GetLatestArticle();
        List<Article> GetLatestFiveArticlesByCategoryId(uint categoryId);
        List<Article> GetArticlesByCategoryId(uint categoryId);
        List<Article> SearchArticlesByTitle(string pattern);
        void AddArticle(Article article);
        void DeleteArticleById(uint id);
        void UpdateArticle(Article article);
    }
}