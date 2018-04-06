using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MultipleDbContextEfCoreDemo.Configuration;
using MultipleDbContextEfCoreDemo.Web;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    public class MultipleDbContextEfCoreDemoSecondDbContextFactory : IDesignTimeDbContextFactory<MultipleDbContextEfCoreDemoSecondDbContext>
    {
        public MultipleDbContextEfCoreDemoSecondDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MultipleDbContextEfCoreDemoSecondDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SecondDbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(MultipleDbContextEfCoreDemoConsts.SecondDbConnectionStringName)
            );

            return new MultipleDbContextEfCoreDemoSecondDbContext(builder.Options);
        }
    }
}