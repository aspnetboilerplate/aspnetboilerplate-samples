using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.HeroShop.Authorization;

namespace Acme.HeroShop
{
    [DependsOn(
        typeof(HeroShopCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class HeroShopApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<HeroShopAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(HeroShopApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
