using Microsoft.EntityFrameworkCore;

namespace Acme.PhoneBook.EntityFrameworkCore
{
    public static class PhoneBookDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PhoneBookDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }
    }
}