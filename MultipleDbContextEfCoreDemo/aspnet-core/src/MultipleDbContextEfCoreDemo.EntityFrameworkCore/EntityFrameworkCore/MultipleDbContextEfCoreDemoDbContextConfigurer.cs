using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    public static class MultipleDbContextEfCoreDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MultipleDbContextEfCoreDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MultipleDbContextEfCoreDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
