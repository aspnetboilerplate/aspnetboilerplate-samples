using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using HealthCheckExample.Configuration;
using HealthCheckExample.Web;

namespace HealthCheckExample.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class HealthCheckExampleDbContextFactory : IDesignTimeDbContextFactory<HealthCheckExampleDbContext>
    {
        public HealthCheckExampleDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HealthCheckExampleDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            HealthCheckExampleDbContextConfigurer.Configure(builder, configuration.GetConnectionString(HealthCheckExampleConsts.ConnectionStringName));

            return new HealthCheckExampleDbContext(builder.Options);
        }
    }
}
