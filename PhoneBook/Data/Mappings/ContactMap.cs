using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.Data.Mappings
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // PRIMARY KEY IDENTITY (1,1)

            builder.Property(x => x.Name)
                .IsRequired() // NOT NULL
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
        }
    }
}