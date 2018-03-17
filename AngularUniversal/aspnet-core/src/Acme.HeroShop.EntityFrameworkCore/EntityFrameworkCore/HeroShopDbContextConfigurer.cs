using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Acme.HeroShop.EntityFrameworkCore
{
    public static class HeroShopDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HeroShopDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HeroShopDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
