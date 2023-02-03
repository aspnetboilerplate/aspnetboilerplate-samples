using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpCoreEf7JsonColumnDemo.Authorization.Roles;
using AbpCoreEf7JsonColumnDemo.Authorization.Users;
using AbpCoreEf7JsonColumnDemo.MultiTenancy;

namespace AbpCoreEf7JsonColumnDemo.EntityFrameworkCore
{
    public class AbpCoreEf7JsonColumnDemoDbContext : AbpZeroDbContext<Tenant, Role, User, AbpCoreEf7JsonColumnDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpCoreEf7JsonColumnDemoDbContext(DbContextOptions<AbpCoreEf7JsonColumnDemoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tenant>().OwnsOne(tenant => tenant.Metadata, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });
        }
    }
}
