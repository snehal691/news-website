using System;
using System.Collections.Generic;

namespace News.Models
{
    public partial class Article
    {
        public Article()
        {
            ArticleCategory = new HashSet<ArticleCategory>();
            ArticleComment = new HashSet<ArticleComment>();
        }

        public uint Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }

        public ICollection<ArticleCategory> ArticleCategory { get; set; }
        public ICollection<ArticleComment> ArticleComment { get; set; }
    }
}
