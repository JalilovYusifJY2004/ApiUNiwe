namespace PestKitOnionAB104.Domain.Entities
{
    public class Tag:BaseNameableEntity
    {
        public ICollection<BlogTag>? BlogTags { get; set; }
    }   
}
