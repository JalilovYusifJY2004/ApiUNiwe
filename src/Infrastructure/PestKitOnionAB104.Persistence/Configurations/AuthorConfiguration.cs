using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Persistence.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a=>a.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(a => a.Name).IsUnique();
        }
    }
}
