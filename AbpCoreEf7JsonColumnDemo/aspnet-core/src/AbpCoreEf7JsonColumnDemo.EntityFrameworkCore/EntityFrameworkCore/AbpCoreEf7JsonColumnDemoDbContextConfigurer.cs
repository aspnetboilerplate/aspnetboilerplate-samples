using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpCoreEf7JsonColumnDemo.EntityFrameworkCore
{
    public static class AbpCoreEf7JsonColumnDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpCoreEf7JsonColumnDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpCoreEf7JsonColumnDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
