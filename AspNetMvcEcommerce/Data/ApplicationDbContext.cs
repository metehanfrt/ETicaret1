using Microsoft.EntityFrameworkCore;

namespace AspNetMvcEcommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //veri tabanı ilişkilendirmesi yapıyoruz
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; } //1-1
        public DbSet<ProductImage> ProductImages { get; set; } //1-N

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model Configurations
            new ProductMap().Configure(modelBuilder.Entity<Product>());
            new CategoryMap().Configure(modelBuilder.Entity<Category>());

            // Model Seeders
            CategorySeeder.SeedData(modelBuilder);
            ProductSeeder.SeedData(modelBuilder);


             
        }
    }
}
