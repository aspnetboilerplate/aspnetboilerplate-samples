using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HealthCheckExample.EntityFrameworkCore
{
    public static class HealthCheckExampleDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HealthCheckExampleDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HealthCheckExampleDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
