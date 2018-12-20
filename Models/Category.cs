using System.Collections.Generic;

namespace News.Models
{
    public partial class Category
    {
        public Category()
        {
            ArticleCategory = new HashSet<ArticleCategory>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public ICollection<ArticleCategory> ArticleCategory { get; set; }
    }
}
