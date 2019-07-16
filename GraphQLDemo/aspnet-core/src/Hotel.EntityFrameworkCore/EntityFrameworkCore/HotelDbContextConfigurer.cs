using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Hotel.EntityFrameworkCore
{
    public static class HotelDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HotelDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HotelDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
