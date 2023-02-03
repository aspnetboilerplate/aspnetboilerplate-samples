using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreEf7JsonColumnDemo.Authorization;

namespace AbpCoreEf7JsonColumnDemo
{
    [DependsOn(
        typeof(AbpCoreEf7JsonColumnDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpCoreEf7JsonColumnDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpCoreEf7JsonColumnDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpCoreEf7JsonColumnDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
