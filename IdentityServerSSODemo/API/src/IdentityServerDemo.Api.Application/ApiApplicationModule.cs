using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace IdentityServerDemo.Api
{
    [DependsOn(
        typeof(ApiCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ApiApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ApiApplicationModule).GetAssembly());
        }
    }
}