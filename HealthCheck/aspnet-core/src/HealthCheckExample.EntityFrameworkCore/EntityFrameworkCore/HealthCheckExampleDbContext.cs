using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HealthCheckExample.Authorization.Roles;
using HealthCheckExample.Authorization.Users;
using HealthCheckExample.MultiTenancy;

namespace HealthCheckExample.EntityFrameworkCore
{
    public class HealthCheckExampleDbContext : AbpZeroDbContext<Tenant, Role, User, HealthCheckExampleDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public HealthCheckExampleDbContext(DbContextOptions<HealthCheckExampleDbContext> options)
            : base(options)
        {
        }
    }
}
