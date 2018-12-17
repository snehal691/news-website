using System;
using System.Collections.Generic;

namespace News
{
    public partial class CommentArticle
    {
        public uint Id { get; set; }
        public uint CommentId { get; set; }
        public uint ArticleId { get; set; }

        public Article Article { get; set; }
        public Comment Comment { get; set; }
    }
}
