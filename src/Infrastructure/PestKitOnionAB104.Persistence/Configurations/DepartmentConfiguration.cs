using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Persistence.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(d => d.Name).IsUnique();
        }
    }
}
