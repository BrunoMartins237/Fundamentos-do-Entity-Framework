using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Models;

namespace PhoneBook.Data.Mapping
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {   // Tabela

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

            //indices
            builder.HasIndex(x => x.Name, "IX_Contact_Name")
                .IsUnique();

            //relacionamentos
        } 
    }
}