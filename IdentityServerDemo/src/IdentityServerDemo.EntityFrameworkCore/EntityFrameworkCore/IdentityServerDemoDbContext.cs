using Abp.IdentityServer4;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IdentityServerDemo.Authorization.Roles;
using IdentityServerDemo.Authorization.Users;
using IdentityServerDemo.MultiTenancy;

namespace IdentityServerDemo.EntityFrameworkCore
{
    public class IdentityServerDemoDbContext : AbpZeroDbContext<Tenant, Role, User, IdentityServerDemoDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define an IDbSet for each entity of the application */
        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public IdentityServerDemoDbContext(DbContextOptions<IdentityServerDemoDbContext> options)
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
