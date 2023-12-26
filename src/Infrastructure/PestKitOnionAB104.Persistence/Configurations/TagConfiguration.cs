using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Persistence.Configurations
{
    internal class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(t => t.Name).IsUnique();
        }
    }
}
