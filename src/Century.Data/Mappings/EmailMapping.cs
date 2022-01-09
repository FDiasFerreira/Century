using Century.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Century.Data.Mappings
{
    public class EmailMapping : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.EmailAddress)
                .IsRequired()
                .HasColumnType("varchar(100)");


            builder.ToTable("Tb_E-mails");
        }
    }
}
