using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultipleDbContextEfCoreDemo.Authorization;

namespace MultipleDbContextEfCoreDemo
{
    [DependsOn(
        typeof(MultipleDbContextEfCoreDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MultipleDbContextEfCoreDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MultipleDbContextEfCoreDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MultipleDbContextEfCoreDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
