using System;
using System.Collections.Generic;

namespace News
{
    public partial class Article
    {
        public Article()
        {
            CategoryArticle = new HashSet<CategoryArticle>();
            CommentArticle = new HashSet<CommentArticle>();
        }

        public uint Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }

        public ICollection<CategoryArticle> CategoryArticle { get; set; }
        public ICollection<CommentArticle> CommentArticle { get; set; }
    }
}
