using App.Infrastructure.Data.Entity;
using App.Infrastructure.Data.Seeder;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                var cs = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlServer(cs);
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model Configurations
            new ProductMap().Configure(modelBuilder.Entity<Product>());
            new CategoryMap().Configure(modelBuilder.Entity<Category>());

            // Model Seeders
            CategorySeeder.SeedData(modelBuilder);
            ProductSeeder.SeedData(modelBuilder);
            UserSeeder.SeedData(modelBuilder);
        }
    }
}
