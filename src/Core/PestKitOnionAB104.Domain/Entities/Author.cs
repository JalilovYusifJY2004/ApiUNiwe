namespace PestKitOnionAB104.Domain.Entities
{
    public class Author:BaseNameableEntity
    {
        public ICollection<Blog>? Blogs { get; set; }
    }
}
