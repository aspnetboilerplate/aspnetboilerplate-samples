using System.Threading.Tasks;
using Abp.Zero.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using IdentityServerWithEfCoreDemo.Authorization.Roles;
using IdentityServerWithEfCoreDemo.Authorization.Users;
using IdentityServerWithEfCoreDemo.EntityFrameworkCore.IdentityServer;
using IdentityServerWithEfCoreDemo.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerWithEfCoreDemo.EntityFrameworkCore
{
    public class IdentityServerWithEfCoreDemoDbContext :
        AbpZeroDbContext<Tenant, Role, User, IdentityServerWithEfCoreDemoDbContext>,
        IConfigurationDbContext,
        IPersistedGrantDbContext
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Client> Clients { get; set; }
        public DbSet<IdentityResource> IdentityResources { get; set; }
        public DbSet<ApiResource> ApiResources { get; set; }
        public DbSet<PersistedGrant> PersistedGrants { get; set; }
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }

        async Task<int> IPersistedGrantDbContext.SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        async Task<int> IConfigurationDbContext.SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public IdentityServerWithEfCoreDemoDbContext(DbContextOptions<IdentityServerWithEfCoreDemoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureClientContext(IdentityServerStoreOptionsProvider.Instance.ConfigurationStoreOptions);
            modelBuilder.ConfigureResourcesContext(IdentityServerStoreOptionsProvider.Instance.ConfigurationStoreOptions);
            modelBuilder.ConfigurePersistedGrantContext(IdentityServerStoreOptionsProvider.Instance.OperationalStoreOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}
