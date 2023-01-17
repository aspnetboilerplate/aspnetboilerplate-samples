using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MassTransitSample.EntityFrameworkCore
{
    public static class MassTransitSampleDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MassTransitSampleDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MassTransitSampleDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
