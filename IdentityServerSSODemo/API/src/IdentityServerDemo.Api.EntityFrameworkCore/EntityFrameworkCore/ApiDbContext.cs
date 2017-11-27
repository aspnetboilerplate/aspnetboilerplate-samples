using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerDemo.Api.EntityFrameworkCore
{
    public class ApiDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public ApiDbContext(DbContextOptions<ApiDbContext> options) 
            : base(options)
        {

        }
    }
}
