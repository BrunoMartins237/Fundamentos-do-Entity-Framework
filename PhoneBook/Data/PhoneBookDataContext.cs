using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Data
{
    public class PhoneBookDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=PhoneBook;User ID=sa;Password=1q2w3e4r@#$");
    }
}