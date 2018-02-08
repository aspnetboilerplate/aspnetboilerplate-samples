using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Volo.SqliteDemo.EntityFrameworkCore
{
    public static class SqliteDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SqliteDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlite(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SqliteDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlite(connection);
        }
    }
}
