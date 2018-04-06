using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Volo.PostgreSqlDemo.EntityFrameworkCore
{
    public static class PostgreSqlDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PostgreSqlDemoDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PostgreSqlDemoDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
