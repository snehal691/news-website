using System;
using System.Collections.Generic;

namespace News
{
    public partial class CategoryArticle
    {
        public uint Id { get; set; }
        public uint ArticleId { get; set; }
        public uint CategoryId { get; set; }

        public Article Article { get; set; }
        public Category Category { get; set; }
    }
}
