using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServervNextDemo.Authorization;

namespace IdentityServervNextDemo
{
    [DependsOn(
        typeof(IdentityServervNextDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IdentityServervNextDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IdentityServervNextDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdentityServervNextDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
