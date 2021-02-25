using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreEf6Sample.Authorization;

namespace AbpCoreEf6Sample
{
    [DependsOn(
        typeof(AbpCoreEf6SampleCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpCoreEf6SampleApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpCoreEf6SampleAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpCoreEf6SampleApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
