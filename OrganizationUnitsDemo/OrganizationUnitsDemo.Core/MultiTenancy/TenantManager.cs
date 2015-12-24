using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using OrganizationUnitsDemo.Authorization.Roles;
using OrganizationUnitsDemo.Editions;
using OrganizationUnitsDemo.Users;

namespace OrganizationUnitsDemo.MultiTenancy
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