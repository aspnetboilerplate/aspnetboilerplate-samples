using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AbpCoreEf6Sample.Configuration;
using AbpCoreEf6Sample.Web;

namespace AbpCoreEf6Sample.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpCoreEf6SampleDbContextFactory : IDesignTimeDbContextFactory<AbpCoreEf6SampleDbContext>
    {
        public AbpCoreEf6SampleDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpCoreEf6SampleDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpCoreEf6SampleDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpCoreEf6SampleConsts.ConnectionStringName));

            return new AbpCoreEf6SampleDbContext(builder.Options);
        }
    }
}
