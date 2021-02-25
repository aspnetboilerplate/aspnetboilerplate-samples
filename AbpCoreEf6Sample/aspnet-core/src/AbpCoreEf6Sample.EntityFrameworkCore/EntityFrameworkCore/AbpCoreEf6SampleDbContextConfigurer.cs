using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpCoreEf6Sample.EntityFrameworkCore
{
    public static class AbpCoreEf6SampleDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpCoreEf6SampleDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpCoreEf6SampleDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
