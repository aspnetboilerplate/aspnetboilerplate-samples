using IdentityServerDemo.Configuration;
using IdentityServerDemo.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace IdentityServerDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class IdentityServerDemoDbContextFactory : IDbContextFactory<IdentityServerDemoDbContext>
    {
        public IdentityServerDemoDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<IdentityServerDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            IdentityServerDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IdentityServerDemoConsts.ConnectionStringName));
            
            return new IdentityServerDemoDbContext(builder.Options);
        }
    }
}