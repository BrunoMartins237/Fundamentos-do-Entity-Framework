﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneBook.Data;

namespace PhoneBook.Migrations
{
    [DbContext(typeof(PhoneBookDataContext))]
    [Migration("20220303221906_RelacionamentoCategoryWithPhoneNumber")]
    partial class RelacionamentoCategoryWithPhoneNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactCategory", b =>
                {
                    b.Property<int>("FK_ContactCategory_CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("FK_ContactCategory_ContactId")
                        .HasColumnType("int");

                    b.HasKey("FK_ContactCategory_CategoryId", "FK_ContactCategory_ContactId");

                    b.HasIndex("FK_ContactCategory_ContactId");

                    b.ToTable("ContactCategory");
                });

            modelBuilder.Entity("PhoneBook.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "IX_Category_Name")
                        .IsUnique();

                    b.ToTable("Category");
                });

            modelBuilder.Entity("PhoneBook.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "IX_Contact_Name")
                        .IsUnique();

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("PhoneBook.Models.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactsId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)")
                        .HasColumnName("Number");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("ContactsId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("ContactCategory", b =>
                {
                    b.HasOne("PhoneBook.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("FK_ContactCategory_CategoryId")
                        .HasConstraintName("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PhoneBook.Models.Contact", null)
                        .WithMany()
                        .HasForeignKey("FK_ContactCategory_ContactId")
                        .HasConstraintName("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhoneBook.Models.PhoneNumber", b =>
                {
                    b.HasOne("PhoneBook.Models.Category", "Categories")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("CategoriesId")
                        .HasConstraintName("Fk_PhoneNumner_Contact")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhoneBook.Models.Contact", "Contacts")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactsId")
                        .HasConstraintName("FK_PhoneNumber_Contact")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Categories");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("PhoneBook.Models.Category", b =>
                {
                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("PhoneBook.Models.Contact", b =>
                {
                    b.Navigation("PhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
