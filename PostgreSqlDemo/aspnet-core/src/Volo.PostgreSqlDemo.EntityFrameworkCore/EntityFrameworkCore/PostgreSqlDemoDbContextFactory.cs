using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.PostgreSqlDemo.Configuration;
using Volo.PostgreSqlDemo.Web;

namespace Volo.PostgreSqlDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PostgreSqlDemoDbContextFactory : IDesignTimeDbContextFactory<PostgreSqlDemoDbContext>
    {
        public PostgreSqlDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PostgreSqlDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            PostgreSqlDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PostgreSqlDemoConsts.ConnectionStringName));

            return new PostgreSqlDemoDbContext(builder.Options);
        }
    }
}
