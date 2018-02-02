using Microsoft.EntityFrameworkCore;

namespace Acme.ProjectName.EntityFrameworkCore
{
    public static class ProjectNameDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ProjectNameDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }
    }
}