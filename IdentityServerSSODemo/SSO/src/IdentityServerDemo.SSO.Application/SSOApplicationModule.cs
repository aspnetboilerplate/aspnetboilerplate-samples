using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerDemo.SSO.Authorization;

namespace IdentityServerDemo.SSO
{
    [DependsOn(
        typeof(SSOCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SSOApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SSOAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SSOApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}
