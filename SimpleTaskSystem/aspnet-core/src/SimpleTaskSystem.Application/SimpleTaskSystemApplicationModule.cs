using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SimpleTaskSystem.Authorization;

namespace SimpleTaskSystem
{
    [DependsOn(
        typeof(SimpleTaskSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SimpleTaskSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SimpleTaskSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SimpleTaskSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
