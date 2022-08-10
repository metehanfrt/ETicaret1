using Microsoft.EntityFrameworkCore;

namespace AspNetMvcEcommerce.Data
{
    public class CategorySeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var initialCategories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Elektronik", CreatetAt = DateTime.Now },
                new Category() { Id = 2, Name = "Kitap", CreatetAt = DateTime.Now },
                new Category() { Id = 3, Name = "Giyim", CreatetAt = DateTime.Now },
                new Category() { Id = 4, ParentId = 2, Name = "Roman", CreatetAt = DateTime.Now },
            };
            modelBuilder.Entity<Category>().HasData(initialCategories);
        }
    }
}
