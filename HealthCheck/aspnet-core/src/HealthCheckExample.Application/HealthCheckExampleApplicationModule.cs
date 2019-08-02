using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HealthCheckExample.Authorization;

namespace HealthCheckExample
{
    [DependsOn(
        typeof(HealthCheckExampleCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class HealthCheckExampleApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<HealthCheckExampleAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(HealthCheckExampleApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
