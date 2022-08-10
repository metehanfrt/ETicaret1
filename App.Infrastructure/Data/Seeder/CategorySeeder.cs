using App.Infrastructure.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data.Seeder
{
    public class CategorySeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var initialCategories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Elektronik", CreatedAt = DateTime.Now },
                new Category() { Id = 2, Name = "Kitap", CreatedAt = DateTime.Now },
                new Category() { Id = 3, Name = "Giyim", CreatedAt = DateTime.Now },
                new Category() { Id = 4, ParentId = 2, Name = "Roman", CreatedAt = DateTime.Now },
                new Category() { Id = 5, ParentId = 3, Name = "Pantolon", CreatedAt = DateTime.Now },
                new Category() { Id = 6, ParentId = 3, Name = "Gömlek", CreatedAt = DateTime.Now },
                new Category() { Id = 7, ParentId = 1, Name = "Cep Telefonu", CreatedAt = DateTime.Now },
                new Category() { Id = 8, ParentId = 1, Name = "Televizyon", CreatedAt = DateTime.Now },
                new Category() { Id = 9, ParentId = 7, Name = "Android", CreatedAt = DateTime.Now },
                new Category() { Id = 10, ParentId = 7, Name = "Apple", CreatedAt = DateTime.Now },
                new Category() { Id = 11, Name = "Oyuncak", CreatedAt = DateTime.Now },
            };

            modelBuilder.Entity<Category>().HasData(initialCategories);
        }
    }
}
