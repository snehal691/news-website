using System;
using System.Collections.Generic;

namespace News
{
    public partial class Category
    {
        public Category()
        {
            CategoryArticle = new HashSet<CategoryArticle>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public ICollection<CategoryArticle> CategoryArticle { get; set; }
    }
}
