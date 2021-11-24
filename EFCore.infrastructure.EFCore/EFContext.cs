using EFCore.Domain.ProductAgg;
using EFCore.Domain.ProductCategoryAgg;
using EFCore.infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EFCore.infrastructure.EFCore
{
    public class EFContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)   
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductMapping());
            //modelBuilder.ApplyConfiguration(new CategoryMapping());

            //Better method
            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}