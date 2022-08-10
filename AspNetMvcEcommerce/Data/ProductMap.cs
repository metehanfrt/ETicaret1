using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetMvcEcommerce.Data
{
    public class ProductMap : IEntityTypeConfiguration<Product> //kalıtım aldığımız sınıf configuration sınıfı  (product)
    {
        public void Configure(EntityTypeBuilder<Product> builder) //Configure ismini yukarıdaki gibi kullanmak zorundayız interface
        {
            builder.ToTable("Product"); //tablonun adı

            builder
               .Property(s => s.Name)
               .HasMaxLength(200);
        }
    }
}
