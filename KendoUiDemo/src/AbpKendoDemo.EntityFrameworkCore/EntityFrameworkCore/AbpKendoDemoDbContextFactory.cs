using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AbpKendoDemo.Configuration;
using AbpKendoDemo.Web;

namespace AbpKendoDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpKendoDemoDbContextFactory : IDesignTimeDbContextFactory<AbpKendoDemoDbContext>
    {
        public AbpKendoDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpKendoDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpKendoDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpKendoDemoConsts.ConnectionStringName));

            return new AbpKendoDemoDbContext(builder.Options);
        }
    }
}
