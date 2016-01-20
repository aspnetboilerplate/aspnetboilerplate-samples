using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using BackgroundJobAndNotificationsDemo.Authorization.Roles;
using BackgroundJobAndNotificationsDemo.Editions;
using BackgroundJobAndNotificationsDemo.Users;

namespace BackgroundJobAndNotificationsDemo.MultiTenancy
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