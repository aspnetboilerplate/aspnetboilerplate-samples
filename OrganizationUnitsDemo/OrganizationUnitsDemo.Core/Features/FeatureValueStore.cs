using Abp.Application.Features;
using OrganizationUnitsDemo.Authorization.Roles;
using OrganizationUnitsDemo.MultiTenancy;
using OrganizationUnitsDemo.Users;

namespace OrganizationUnitsDemo.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}