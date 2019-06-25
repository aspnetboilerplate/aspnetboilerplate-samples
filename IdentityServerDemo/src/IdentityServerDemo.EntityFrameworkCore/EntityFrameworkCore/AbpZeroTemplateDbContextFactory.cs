using IdentityServerDemo.Configuration;
using IdentityServerDemo.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace IdentityServerDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class IdentityServerDemoDbContextFactory : IDesignTimeDbContextFactory<IdentityServerDemoDbContext>
    {
        public IdentityServerDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IdentityServerDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            IdentityServerDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IdentityServerDemoConsts.ConnectionStringName));

            return new IdentityServerDemoDbContext(builder.Options);
        }
    }
}