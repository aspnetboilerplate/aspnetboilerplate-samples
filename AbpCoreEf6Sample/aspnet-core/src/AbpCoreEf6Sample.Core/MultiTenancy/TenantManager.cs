using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using AbpCoreEf6Sample.Authorization.Users;
using AbpCoreEf6Sample.Editions;

namespace AbpCoreEf6Sample.MultiTenancy
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
