using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Volo.PostgreSqlDemo.Authorization;

namespace Volo.PostgreSqlDemo
{
    [DependsOn(
        typeof(PostgreSqlDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PostgreSqlDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PostgreSqlDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PostgreSqlDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
