using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Hotel.Configuration;
using Hotel.Web;

namespace Hotel.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class HotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
    {
        public HotelDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HotelDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            HotelDbContextConfigurer.Configure(builder, configuration.GetConnectionString(HotelConsts.ConnectionStringName));

            return new HotelDbContext(builder.Options);
        }
    }
}
