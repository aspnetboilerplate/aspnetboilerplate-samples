using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace InterceptionDemo.EntityFrameworkCore
{
    public static class InterceptionDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<InterceptionDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<InterceptionDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
