using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IdentityServervNextDemo.EntityFrameworkCore
{
    public static class IdentityServervNextDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IdentityServervNextDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IdentityServervNextDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
