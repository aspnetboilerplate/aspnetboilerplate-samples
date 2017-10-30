using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerDemo.Authorization;

namespace IdentityServerDemo
{
    [DependsOn(
        typeof(IdentityServerDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IdentityServerDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IdentityServerDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdentityServerDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}
