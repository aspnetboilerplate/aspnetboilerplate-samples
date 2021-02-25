using System.Data.Entity;
using Abp.Zero.EntityFramework;
using AbpCoreEf6Sample.Authorization.Roles;
using AbpCoreEf6Sample.Authorization.Users;
using AbpCoreEf6Sample.MultiTenancy;

namespace AbpCoreEf6Sample.EntityFrameworkCore
{
    public class AbpCoreEf6SampleDbContext : AbpZeroDbContext<Tenant, Role, User, AbpCoreEf6SampleDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpCoreEf6SampleDbContext(DbContextOptions<AbpCoreEf6SampleDbContext> options)
            : base(options)
        {
        }
    }
}
