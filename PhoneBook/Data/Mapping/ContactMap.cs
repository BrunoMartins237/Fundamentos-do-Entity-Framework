using System.Collections.Generic;
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
            
            // para adicionar essa coluna [email] no banco, é preciso executar uma migration e depos atualizar.
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            //indices
            builder.HasIndex(x => x.Name, "IX_Contact_Name")
                .IsUnique();

            //relacionamentos many to many
            builder
            .HasMany(x => x.Categories)
            .WithMany(x => x.Contacts)
            .UsingEntity<Dictionary<string, object>>(
                "ContactCategory",
                category => category
                .HasOne<Category>()
                .WithMany()
                .HasConstraintName("CategoryId")
                .HasForeignKey("FK_ContactCategory_CategoryId")
                .OnDelete(DeleteBehavior.Cascade),
                contact => contact
                .HasOne<Contact>()
                .WithMany()
                .HasConstraintName("ContactId")
                .HasForeignKey("FK_ContactCategory_ContactId")
                .OnDelete(DeleteBehavior.Cascade)
            );
        } 
    }
}