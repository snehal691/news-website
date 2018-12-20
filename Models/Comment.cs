using System;
using System.Collections.Generic;

namespace News.Models
{
    public partial class Comment
    {
        public Comment()
        {
            ArticleComment = new HashSet<ArticleComment>();
            CommentPerson = new HashSet<CommentPerson>();
        }

        public uint Id { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        public ICollection<ArticleComment> ArticleComment { get; set; }
        public ICollection<CommentPerson> CommentPerson { get; set; }
    }
}
