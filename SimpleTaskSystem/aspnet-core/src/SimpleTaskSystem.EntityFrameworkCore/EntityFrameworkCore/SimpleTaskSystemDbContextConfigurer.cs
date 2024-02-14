using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SimpleTaskSystem.EntityFrameworkCore
{
    public static class SimpleTaskSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SimpleTaskSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SimpleTaskSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
