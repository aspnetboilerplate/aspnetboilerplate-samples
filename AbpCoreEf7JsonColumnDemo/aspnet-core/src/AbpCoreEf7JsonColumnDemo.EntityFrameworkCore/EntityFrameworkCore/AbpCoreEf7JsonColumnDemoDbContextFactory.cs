using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AbpCoreEf7JsonColumnDemo.Configuration;
using AbpCoreEf7JsonColumnDemo.Web;

namespace AbpCoreEf7JsonColumnDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpCoreEf7JsonColumnDemoDbContextFactory : IDesignTimeDbContextFactory<AbpCoreEf7JsonColumnDemoDbContext>
    {
        public AbpCoreEf7JsonColumnDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpCoreEf7JsonColumnDemoDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpCoreEf7JsonColumnDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpCoreEf7JsonColumnDemoConsts.ConnectionStringName));

            return new AbpCoreEf7JsonColumnDemoDbContext(builder.Options);
        }
    }
}
