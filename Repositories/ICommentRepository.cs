using System.Collections.Generic;
using News.Models;

namespace News.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsByArticleId(uint articleId);
        string GetPersonNicknameByCommentId(uint commentId);
        void AddComment(Comment comment);
        void DeleteCommentById(uint commentId);
    }
}