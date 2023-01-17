using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MassTransitSample.Authorization;

namespace MassTransitSample
{
    [DependsOn(
        typeof(MassTransitSampleCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MassTransitSampleApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MassTransitSampleAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MassTransitSampleApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
