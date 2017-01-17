using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
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
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}