using System;

namespace News.Models
{
    public partial class Comment
    {
        public uint Id { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public uint ArticleId { get; set; }
        public uint PersonId { get; set; }
    }
}
