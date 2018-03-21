using MultipleDbContextEfCoreDemo.Configuration;
using MultipleDbContextEfCoreDemo.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class MultipleDbContextEfCoreDemoDbContextFactory : IDesignTimeDbContextFactory<MultipleDbContextEfCoreDemoDbContext>
    {
        public MultipleDbContextEfCoreDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MultipleDbContextEfCoreDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(MultipleDbContextEfCoreDemoConsts.ConnectionStringName)
            );

            return new MultipleDbContextEfCoreDemoDbContext(builder.Options);
        }
    }

    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
}