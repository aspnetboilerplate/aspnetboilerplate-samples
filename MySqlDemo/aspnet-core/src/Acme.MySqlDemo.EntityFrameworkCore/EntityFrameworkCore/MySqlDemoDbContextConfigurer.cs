using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Acme.MySqlDemo.EntityFrameworkCore
{
    public static class MySqlDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MySqlDemoDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString, mySqlOptionsAction =>
            {
                mySqlOptionsAction.MigrationsAssembly(typeof(MySqlDemoDbContextConfigurer).Assembly.GetName().Name);
            });
        }

        public static void Configure(DbContextOptionsBuilder<MySqlDemoDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection, mySqlOptionsAction =>
            {
                mySqlOptionsAction.MigrationsAssembly(typeof(MySqlDemoDbContextConfigurer).Assembly.GetName().Name);
            });
        }
    }
}
