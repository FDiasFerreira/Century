using Century.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Century.Data.Mappings
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Active)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.FantasyName)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.Name)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.SupplierType)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.Document)
               .IsRequired()
               .HasColumnType("varchar(14)");

            builder.Property(p => p.BirthDate)
               .IsRequired()
               .HasColumnType("varchar(200)");


            builder.HasOne(s => s.Address)
            .WithOne(a => a.Supplier);           

            builder.HasOne(s => s.Email)
                .WithOne(e => e.Supplier);

            builder.HasOne(s => s.Phone)
                .WithOne(p => p.Supplier);                

            builder.HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);

            builder.ToTable("Tb_Suppliers");

        }
    }
}
