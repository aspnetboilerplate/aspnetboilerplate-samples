using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Volo.PostgreSqlDemo.Authorization.Users;
using Volo.PostgreSqlDemo.Editions;

namespace Volo.PostgreSqlDemo.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
