using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Volo.SqliteDemo.Authorization;

namespace Volo.SqliteDemo
{
    [DependsOn(
        typeof(SqliteDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SqliteDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SqliteDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SqliteDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
