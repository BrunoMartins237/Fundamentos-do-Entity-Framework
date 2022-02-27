using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Mapping;
using PhoneBook.Models;

namespace PhoneBook.Data
{
    public class PhoneBookDataContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<PhoneNumber> MyProperty { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=phonebook;User ID=sa;Password=1q2w3e4r@#$");

        // método OnModelCreating informa ao datacontext que contém arquivos de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new PhoneNumberMap());
        }
    }
}