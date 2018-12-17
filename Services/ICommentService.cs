using System.Collections.Generic;

namespace News.Service
{
    public interface ICommentService
    {
        List<Comment> GetCommentsByArticleId(int articleId);
        void AddComment(Comment comment);
        void DeleteCommentById(int id);
    }
}