using Century.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Century.Data.Mappings
{
    public class PhoneMapping : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Ddd)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(p => p.Number)
                .IsRequired()
                .HasColumnType("varchar(9)");


            builder.ToTable("Tb_Phones");
        }
    }
}
