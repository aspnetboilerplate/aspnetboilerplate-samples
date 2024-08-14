using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    public static class MultipleDbContextEfCoreDemoSecondDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MultipleDbContextEfCoreDemoSecondDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MultipleDbContextEfCoreDemoSecondDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
