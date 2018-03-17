using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpKendoDemo.EntityFrameworkCore
{
    public static class AbpKendoDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpKendoDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpKendoDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
