namespace News.Models
{
    public partial class ArticleCategory
    {
        public uint Id { get; set; }
        public uint ArticleId { get; set; }
        public uint? CategoryId { get; set; }

        public Article Article { get; set; }
        public Category Category { get; set; }
    }
}
