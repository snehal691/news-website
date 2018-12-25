using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using News.Models;

namespace News.Repositories
{
    public class CommentRepository : ICommentRepository, IDisposable
    {
        private readonly NewsContext _newsContext;

        public CommentRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public List<Comment> GetCommentsByArticleId(uint articleId)
        {
//            return _newsContext.Comment
//                .FromSql("SELECT comment.id, comment.content, comment.publish_date " +
//                         "FROM comment, article_comment " +
//                         $"WHERE article_comment.comment_id = comment.id AND article_comment.article_id = {articleId} ")
//                .ToList();
            return _newsContext.Comment
                .Where(c => c.ArticleId == articleId)
                .ToList();
        }

        public string GetPersonNicknameByCommentId(uint commentId)
        {
            var personId = _newsContext.Comment.Find(commentId).PersonId;
            var nickname = _newsContext.Person.Find(personId).Nickname;
            return nickname;
        }
        
        public void AddComment(Comment comment)
        {
            _newsContext.Comment.Add(comment);
            _newsContext.SaveChanges();

//            _newsContext.Comment.Add(comment);
//            _newsContext.SaveChanges();
//
//            var commentId = comment.Id;
//            _newsContext.CommentPerson.Add(new CommentPerson()
//            {
//                CommentId = commentId,
//                PersonId = personId
//            });
//            _newsContext.SaveChanges();
        }

        public void DeleteCommentById(uint commentId)
        {
            _newsContext.Comment.Remove(new Comment()
            {
                Id = commentId
            });
            _newsContext.SaveChanges();
            
//            _newsContext.CommentPerson.Remove(new CommentPerson()
//            {
//                CommentId = commentId
//            });
//
//            _newsContext.ArticleComment.Remove(new ArticleComment()
//            {
//                CommentId = commentId
//            });
//
//            _newsContext.Comment.Remove(new Comment()
//            {
//                Id = commentId
//            });
//            _newsContext.SaveChanges();
        }

        public void Dispose()
        {
            _newsContext?.Dispose();
        }
    }
}