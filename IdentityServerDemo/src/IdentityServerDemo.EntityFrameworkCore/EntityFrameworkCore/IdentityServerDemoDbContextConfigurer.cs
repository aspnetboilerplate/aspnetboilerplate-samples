using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerDemo.EntityFrameworkCore
{
    public static class IdentityServerDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IdentityServerDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IdentityServerDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
