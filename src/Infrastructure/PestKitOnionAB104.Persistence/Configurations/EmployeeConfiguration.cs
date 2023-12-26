using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Persistence.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(d => d.Name).IsUnique();
        }
    }
}
