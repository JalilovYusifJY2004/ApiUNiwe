namespace PestKitOnionAB104.Domain.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string Description { get; set; } = null!;
        public int ReplyCount { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public ICollection<BlogTag>? BlogTags { get; set; }
    }
}
