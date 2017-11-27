using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using IdentityServerDemo.SSO.Configuration;
using IdentityServerDemo.SSO.Web;

namespace IdentityServerDemo.SSO.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SSODbContextFactory : IDesignTimeDbContextFactory<SSODbContext>
    {
        public SSODbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SSODbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SSODbContextConfigurer.Configure(builder, configuration.GetConnectionString(SSOConsts.ConnectionStringName));

            return new SSODbContext(builder.Options);
        }
    }
}
