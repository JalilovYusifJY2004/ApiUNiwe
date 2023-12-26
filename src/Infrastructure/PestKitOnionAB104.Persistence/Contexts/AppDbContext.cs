using Microsoft.EntityFrameworkCore;
using PestKitOnionAB104.Domain;
using PestKitOnionAB104.Domain.Entities;
using System.Reflection;

namespace PestKitOnionAB104.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Position>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Author>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Tag>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Employee>().HasQueryFilter(c => c.IsDeleted == false);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entites = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in entites)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.ModifiedAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedAt = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}