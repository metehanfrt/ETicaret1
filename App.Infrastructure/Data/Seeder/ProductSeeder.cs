using App.Infrastructure.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data.Seeder
{
    public class ProductSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var initialProducts = new List<Product>()
            {
                new Product() {
                    Id = 1,
                    Name = "LG 55A16 55\" 139 CM 4K UHD OLED webOS SMART TV, DAHİLİ UYDU ALICI",
                    Description = "4K 3D Televizyon ile sinema keyfi",
                    Price = 16199,
                    CreatedAt = DateTime.Now
                },
                new Product() {
                    Id = 2,
                    Name = "Kar Romanı",
                    Description = "Nobel ödüllü Türk yazar Orhan Pamuk, 2002 yılında yayımladığı Kar adlı eserinde siyasi ve toplumsal konuları roman penceresinden ele alıyor. Yazarın “ilk ve son siyasi romanım” olarak tanımladığı eser, Kars şehrini merkeze alarak Türkiye’de cehalet ve yobazlık sorunlarını konu ediniyor. Roman, toplumun en hassas konularından olan kadın meselesini irdelemesi bakımından, aynı zamanda kitlesel bir eleştiri niteliği taşıyor.",
                    Price = 14.99m,
                    CreatedAt = DateTime.Now
                },
                new Product() {
                    Id = 3,
                    SKU = "0042433452",
                    Name = "Mavi Erkek TOKK Serisi James 90s Koyu Jean Pantolon",
                    Price= 259.99m,
                    CreatedAt = DateTime.Now
                },
                new Product() {
                    Id = 4,
                    SKU = "0042433453",
                    Name = "Regal 32R604H Televizyon",
                    Description = "Regal 32R604H Televizyon",
                    Price= 4000m,
                    CreatedAt = DateTime.Now
                }
            };
            modelBuilder.Entity<Product>().HasData(initialProducts);


            var initialImages = new List<ProductImage>()
            {
                new ProductImage() { Id = 1, ProductId = 1, ImageUrl = "urun1-1.jpg" },
                new ProductImage() { Id = 2, ProductId = 1, ImageUrl = "urun1-2.webp" },
                new ProductImage() { Id = 3, ProductId = 1, ImageUrl = "urun1-3.webp" },
                new ProductImage() { Id = 4, ProductId = 1, ImageUrl = "urun1-4.jpg" },
            };
            modelBuilder.Entity<ProductImage>().HasData(initialImages);


            var initalDetails = new List<ProductDetail>()
            {
                new ProductDetail() { Id = 1, ProductId = 1, IsVisibleFeatured = true, IsVisibleSlider = false },
                new ProductDetail() { Id = 2, ProductId = 2, IsVisibleFeatured = false, IsVisibleSlider = true },
                new ProductDetail() { Id = 3, ProductId = 3, IsVisibleFeatured = true, IsVisibleSlider = true }
            };
            modelBuilder.Entity<ProductDetail>().HasData(initalDetails);
        }
    }
}
