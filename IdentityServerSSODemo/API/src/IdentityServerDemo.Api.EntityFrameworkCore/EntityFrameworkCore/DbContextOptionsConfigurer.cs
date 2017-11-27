using Microsoft.EntityFrameworkCore;

namespace IdentityServerDemo.Api.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<ApiDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for ApiDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
