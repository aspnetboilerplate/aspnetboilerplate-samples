using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpKendoDemo.Authorization;

namespace AbpKendoDemo
{
    [DependsOn(
        typeof(AbpKendoDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpKendoDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpKendoDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpKendoDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
