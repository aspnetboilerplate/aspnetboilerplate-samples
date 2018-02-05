using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.MySqlDemo.Authorization;

namespace Acme.MySqlDemo
{
    [DependsOn(
        typeof(MySqlDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MySqlDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MySqlDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MySqlDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
