using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Acme.MySqlDemo.Configuration;
using Acme.MySqlDemo.Web;

namespace Acme.MySqlDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MySqlDemoDbContextFactory : IDesignTimeDbContextFactory<MySqlDemoDbContext>
    {
        public MySqlDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MySqlDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MySqlDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MySqlDemoConsts.ConnectionStringName));

            return new MySqlDemoDbContext(builder.Options);
        }
    }
}
