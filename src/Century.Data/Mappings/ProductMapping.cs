using Century.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Century.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.Property(p => p.BarCode)
                 .IsRequired()
                 .HasColumnType("varchar(13)");

            builder.Property(p => p.QuantityStock)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.Property(p => p.PricePurchase)
                .IsRequired()
                .HasColumnType("decimal(5, 2");

            builder.Property(p => p.PriceSales)
            .IsRequired()
            .HasColumnType("decimal(5, 2");

            builder.Property(p => p.ImagePath)
             .IsRequired()
             .HasColumnType("varchar(200)");

            builder.HasOne(p => p.Supplier)
              .WithMany(c => c.Products)
              .HasForeignKey(p => p.SupplierId);

            //builder.HasOne(p => p.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CategoryId);


            builder.ToTable("Tb_Produtos");
        }
    }
    
}
