using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using News.Models;

namespace News.Repositories
{
    public class ArticleRepository : IArticleRepository, IDisposable
    {
        private readonly NewsContext _newsContext;

        public ArticleRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public Article GetArticleById(uint id)
        {
            return _newsContext.Article.Find(id);
        }

        public List<Article> GetAllArticles()
        {
            return _newsContext.Article
                .OrderByDescending(a => a.PublishDate)
                .ToList();
        }

        public Article GetLatestArticle()
        {
            return _newsContext.Article
                .OrderByDescending(a => a.PublishDate)
                .FirstOrDefault();
        }

        public List<Article> GetLatestFiveArticlesByCategoryId(uint categoryId)
        {
            return _newsContext.Article
                .Where(a => a.CategoryId == categoryId)
                .OrderByDescending(a => a.PublishDate)
                .Take(5)
                .ToList();
        }

        public List<Article> GetArticlesByCategoryId(uint categoryId)
        {
            return _newsContext.Article
                .Where(a => a.CategoryId == categoryId)
                .OrderByDescending(a => a.PublishDate)
                .ToList();
        }

        public List<Article> SearchArticlesByTitle(string pattern)
        {
            return _newsContext.Article
                .Where(a => a.Title.Contains(pattern))
                .ToList();
        }

        public void AddArticle(Article article)
        {
            _newsContext.Article.Add(article);
            _newsContext.SaveChanges();
        }

        public void DeleteArticleById(uint id)
        {
            var comments = _newsContext.Comment
                .Where(c => c.ArticleId == id)
                .ToList();
            _newsContext.Comment.RemoveRange(comments);

            _newsContext.Article.Remove(new Article()
            {
                Id = id
            });

            _newsContext.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            _newsContext.Article.Update(article);
            _newsContext.SaveChanges();
        }

        public void Dispose()
        {
            _newsContext?.Dispose();
        }
    }
}