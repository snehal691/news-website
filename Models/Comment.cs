using System;
using System.Collections.Generic;

namespace News
{
    public partial class Comment
    {
        public Comment()
        {
            CommentArticle = new HashSet<CommentArticle>();
            CommentPerson = new HashSet<CommentPerson>();
        }

        public uint Id { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        public ICollection<CommentArticle> CommentArticle { get; set; }
        public ICollection<CommentPerson> CommentPerson { get; set; }
    }
}
