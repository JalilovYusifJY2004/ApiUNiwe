namespace PestKitOnionAB104.Domain.Entities
{
    public class BlogTag:BaseEntity
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
