using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using InterceptionDemo.Authorization.Roles;
using InterceptionDemo.Editions;
using InterceptionDemo.Users;

namespace InterceptionDemo.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager
            )
        {
        }
    }
}