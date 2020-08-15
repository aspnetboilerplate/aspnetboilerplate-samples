using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerWithEfCoreDemo.EntityFrameworkCore
{
    public static class IdentityServerWithEfCoreDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IdentityServerWithEfCoreDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IdentityServerWithEfCoreDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
