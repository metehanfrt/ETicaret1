using App.Infrastructure.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data.Seeder
{
    public class UserSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new User {
                    Id = 1,
                    Username = "superadmin",
                    Password = "superadmin",
                    EmailAddress = "superadmin@site.com",
                    IsActive = true,
                    Roles = "SuperAdmin,Admin"
                },
                new User {
                    Id = 2,
                    Username = "cem",
                    Password = "cem",
                    EmailAddress = "cem@site.com",
                    IsActive = true
                },
                new User {
                    Id = 3,
                    Username = "oguzhan",
                    Password = "oguzhan",
                    EmailAddress = "oguzhan@site.com",
                    IsActive = true,
                    Roles = "Admin, CategoryManager, ProductManager"
                },
            });
        }
    }
}
