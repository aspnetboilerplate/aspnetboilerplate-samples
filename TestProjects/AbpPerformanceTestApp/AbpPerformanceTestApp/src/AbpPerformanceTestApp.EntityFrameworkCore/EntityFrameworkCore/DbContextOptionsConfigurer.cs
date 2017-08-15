using Microsoft.EntityFrameworkCore;

namespace AbpPerformanceTestApp.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<AbpPerformanceTestAppDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for AbpPerformanceTestAppDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
