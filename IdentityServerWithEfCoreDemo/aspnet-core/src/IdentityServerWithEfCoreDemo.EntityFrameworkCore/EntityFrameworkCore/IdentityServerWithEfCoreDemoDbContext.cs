using System.Threading.Tasks;
using Abp.Zero.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using IdentityServerWithEfCoreDemo.Authorization.Roles;
using IdentityServerWithEfCoreDemo.Authorization.Users;
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
        async Task<int> IPersistedGrantDbContext.SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<PersistedGrant> PersistedGrants { get; set; }
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }

        async Task<int> IConfigurationDbContext.SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<IdentityResource> IdentityResources { get; set; }
        public DbSet<ApiResource> ApiResources { get; set; }

        protected ConfigurationStoreOptions ConfigurationStoreOptions { get; }
        protected OperationalStoreOptions OperationalStoreOptions { get; }

        public IdentityServerWithEfCoreDemoDbContext(
            DbContextOptions<IdentityServerWithEfCoreDemoDbContext> options,
            ConfigurationStoreOptions configurationStoreOptions,
            OperationalStoreOptions operationalStoreOptions)
            : base(options)
        {
            ConfigurationStoreOptions = configurationStoreOptions;
            OperationalStoreOptions = operationalStoreOptions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureClientContext(ConfigurationStoreOptions);
            modelBuilder.ConfigureResourcesContext(ConfigurationStoreOptions);

            modelBuilder.ConfigurePersistedGrantContext(OperationalStoreOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}
