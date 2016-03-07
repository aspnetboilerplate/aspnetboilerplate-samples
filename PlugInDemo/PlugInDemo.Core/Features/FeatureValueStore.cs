using Abp.Application.Features;
using PlugInDemo.Authorization.Roles;
using PlugInDemo.MultiTenancy;
using PlugInDemo.Users;

namespace PlugInDemo.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}