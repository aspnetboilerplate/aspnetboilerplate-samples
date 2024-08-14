using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MultipleDbContextEfCoreDemo.Configuration;
using MultipleDbContextEfCoreDemo.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MultipleDbContextEfCoreDemoSecondDbContextFactory : IDesignTimeDbContextFactory<MultipleDbContextEfCoreDemoSecondDbContext>
    {
        public MultipleDbContextEfCoreDemoSecondDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MultipleDbContextEfCoreDemoSecondDbContext>();

            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MultipleDbContextEfCoreDemoSecondDbContextConfigurer
                .Configure(builder, configuration
                    .GetConnectionString(MultipleDbContextEfCoreDemoConsts.SecondConnectionStringName));

            return new MultipleDbContextEfCoreDemoSecondDbContext(builder.Options);
        }
    }
}
