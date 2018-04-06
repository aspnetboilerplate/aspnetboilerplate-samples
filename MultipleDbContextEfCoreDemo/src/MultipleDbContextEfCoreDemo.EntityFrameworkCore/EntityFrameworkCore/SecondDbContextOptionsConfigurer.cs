using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    public static class SecondDbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<MultipleDbContextEfCoreDemoSecondDbContext> dbContextOptions,
            string connectionString
        )
        {
            /* This is the single point to configure DbContextOptions for MultipleDbContextEfCoreDemoDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }

        public static void Configure(
            DbContextOptionsBuilder<MultipleDbContextEfCoreDemoSecondDbContext> dbContextOptions,
            DbConnection connection
        )
        {
            /* This is the single point to configure DbContextOptions for MultipleDbContextEfCoreDemoDbContext */
            dbContextOptions.UseSqlServer(connection);
        }
    }
}