using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using IdentityServervNextDemo.Configuration;
using IdentityServervNextDemo.Web;

namespace IdentityServervNextDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class IdentityServervNextDemoDbContextFactory : IDesignTimeDbContextFactory<IdentityServervNextDemoDbContext>
    {
        public IdentityServervNextDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IdentityServervNextDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            IdentityServervNextDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IdentityServervNextDemoConsts.ConnectionStringName));

            return new IdentityServervNextDemoDbContext(builder.Options);
        }
    }
}
