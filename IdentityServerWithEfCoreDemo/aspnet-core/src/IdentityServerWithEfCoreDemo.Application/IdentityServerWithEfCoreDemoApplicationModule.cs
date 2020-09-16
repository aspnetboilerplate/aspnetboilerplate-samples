using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerWithEfCoreDemo.Authorization;

namespace IdentityServerWithEfCoreDemo
{
    [DependsOn(
        typeof(IdentityServerWithEfCoreDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IdentityServerWithEfCoreDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IdentityServerWithEfCoreDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdentityServerWithEfCoreDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
