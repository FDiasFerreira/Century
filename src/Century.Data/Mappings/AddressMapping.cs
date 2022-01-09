using Century.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Century.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Street)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Number)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Complement)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Reference)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Neighborhood)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.City)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.State)
                .IsRequired()
                .HasColumnType("varchar(50)");         
              

            builder.ToTable("Tb_Addresses");
        }
    }
    
}
