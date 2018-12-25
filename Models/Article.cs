using System;

namespace News.Models
{
    public partial class Article
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public uint? CategoryId { get; set; }
    }
}
