using Abp.IdentityServer4;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IdentityServerDemo.SSO.Authorization.Roles;
using IdentityServerDemo.SSO.Authorization.Users;
using IdentityServerDemo.SSO.MultiTenancy;

namespace IdentityServerDemo.SSO.EntityFrameworkCore
{
    public class SSODbContext : AbpZeroDbContext<Tenant, Role, User, SSODbContext>, IAbpPersistedGrantDbContext
    {
        /* Define an IDbSet for each entity of the application */
        
        public SSODbContext(DbContextOptions<SSODbContext> options)
            : base(options)
        {
        }

        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
