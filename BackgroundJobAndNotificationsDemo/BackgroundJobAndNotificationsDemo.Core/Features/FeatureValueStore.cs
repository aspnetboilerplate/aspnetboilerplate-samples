using Abp.Application.Features;
using BackgroundJobAndNotificationsDemo.Authorization.Roles;
using BackgroundJobAndNotificationsDemo.MultiTenancy;
using BackgroundJobAndNotificationsDemo.Users;

namespace BackgroundJobAndNotificationsDemo.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}