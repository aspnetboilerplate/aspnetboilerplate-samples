using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Acme.HeroShop.Authorization.Users;
using Acme.HeroShop.Editions;

namespace Acme.HeroShop.MultiTenancy
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
