using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerDemo.SSO.EntityFrameworkCore
{
    public static class SSODbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SSODbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SSODbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
