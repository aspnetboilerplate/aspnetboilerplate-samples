using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Acme.HeroShop.Configuration;
using Acme.HeroShop.Web;

namespace Acme.HeroShop.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class HeroShopDbContextFactory : IDesignTimeDbContextFactory<HeroShopDbContext>
    {
        public HeroShopDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HeroShopDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            HeroShopDbContextConfigurer.Configure(builder, configuration.GetConnectionString(HeroShopConsts.ConnectionStringName));

            return new HeroShopDbContext(builder.Options);
        }
    }
}
