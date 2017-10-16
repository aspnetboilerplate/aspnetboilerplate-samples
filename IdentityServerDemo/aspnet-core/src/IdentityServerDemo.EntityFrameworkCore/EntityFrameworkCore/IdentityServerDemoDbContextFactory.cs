using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using IdentityServerDemo.Configuration;
using IdentityServerDemo.Web;

namespace IdentityServerDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class IdentityServerDemoDbContextFactory : IDesignTimeDbContextFactory<IdentityServerDemoDbContext>
    {
        public IdentityServerDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IdentityServerDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            IdentityServerDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IdentityServerDemoConsts.ConnectionStringName));

            return new IdentityServerDemoDbContext(builder.Options);
        }
    }
}
