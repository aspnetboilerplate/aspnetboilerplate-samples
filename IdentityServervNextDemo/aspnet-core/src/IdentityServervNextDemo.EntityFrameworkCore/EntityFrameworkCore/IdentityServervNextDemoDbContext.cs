using Abp.IdentityServer4vNext;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IdentityServervNextDemo.Authorization.Roles;
using IdentityServervNextDemo.Authorization.Users;
using IdentityServervNextDemo.MultiTenancy;

namespace IdentityServervNextDemo.EntityFrameworkCore
{
    public class IdentityServervNextDemoDbContext : AbpZeroDbContext<Tenant, Role, User, IdentityServervNextDemoDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public IdentityServervNextDemoDbContext(DbContextOptions<IdentityServervNextDemoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
