using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.SqliteDemo.Configuration;
using Volo.SqliteDemo.Web;

namespace Volo.SqliteDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SqliteDemoDbContextFactory : IDesignTimeDbContextFactory<SqliteDemoDbContext>
    {
        public SqliteDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqliteDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SqliteDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SqliteDemoConsts.ConnectionStringName));

            return new SqliteDemoDbContext(builder.Options);
        }
    }
}
