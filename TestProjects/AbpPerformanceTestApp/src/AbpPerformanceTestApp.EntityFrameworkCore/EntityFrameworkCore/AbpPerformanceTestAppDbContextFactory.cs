using AbpPerformanceTestApp.Configuration;
using AbpPerformanceTestApp.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace AbpPerformanceTestApp.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class AbpPerformanceTestAppDbContextFactory : IDbContextFactory<AbpPerformanceTestAppDbContext>
    {
        public AbpPerformanceTestAppDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<AbpPerformanceTestAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder, 
                configuration.GetConnectionString(AbpPerformanceTestAppConsts.ConnectionStringName)
                );

            return new AbpPerformanceTestAppDbContext(builder.Options);
        }
    }
}