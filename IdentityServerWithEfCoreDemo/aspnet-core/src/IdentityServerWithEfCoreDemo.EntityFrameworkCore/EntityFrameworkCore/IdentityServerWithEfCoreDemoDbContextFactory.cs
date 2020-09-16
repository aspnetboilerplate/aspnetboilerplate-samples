using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using IdentityServerWithEfCoreDemo.Configuration;
using IdentityServerWithEfCoreDemo.Web;

namespace IdentityServerWithEfCoreDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class IdentityServerWithEfCoreDemoDbContextFactory : IDesignTimeDbContextFactory<IdentityServerWithEfCoreDemoDbContext>
    {
        public IdentityServerWithEfCoreDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IdentityServerWithEfCoreDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            IdentityServerWithEfCoreDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IdentityServerWithEfCoreDemoConsts.ConnectionStringName));

            return new IdentityServerWithEfCoreDemoDbContext(builder.Options);
        }
    }
}
