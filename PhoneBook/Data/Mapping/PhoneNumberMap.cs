using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Models;

namespace PhoneBook.Data.Mapping
{
    public class PhoneNumberMap : IEntityTypeConfiguration<PhoneNumber>
{
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumber");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            
            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnName("Number")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            //Relacionamentos
            builder.HasOne(x => x.Contacts)
                .WithMany(x => x.PhoneNumbers)
                .HasConstraintName("FK_PhoneNumber_Contact")
                .OnDelete(DeleteBehavior.SetNull);
        }

       
    }
}
