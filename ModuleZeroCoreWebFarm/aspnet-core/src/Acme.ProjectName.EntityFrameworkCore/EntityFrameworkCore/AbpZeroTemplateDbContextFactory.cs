using Acme.ProjectName.Configuration;
using Acme.ProjectName.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Acme.ProjectName.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ProjectNameDbContextFactory : IDesignTimeDbContextFactory<ProjectNameDbContext>
    {
        public ProjectNameDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProjectNameDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ProjectNameDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ProjectNameConsts.ConnectionStringName));

            return new ProjectNameDbContext(builder.Options);
        }
    }
}