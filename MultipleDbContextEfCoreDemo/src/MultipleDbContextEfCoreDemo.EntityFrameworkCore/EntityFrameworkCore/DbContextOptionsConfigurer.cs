using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<MultipleDbContextEfCoreDemoDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for MultipleDbContextEfCoreDemoDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }

        public static void Configure(
            DbContextOptionsBuilder<MultipleDbContextEfCoreDemoDbContext> dbContextOptions,
            DbConnection connection
        )
        {
            /* This is the single point to configure DbContextOptions for MultipleDbContextEfCoreDemoDbContext */
            dbContextOptions.UseSqlServer(connection);
        }
    }
}
