using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerDemo.Authorization;

namespace IdentityServerDemo
{
    [DependsOn(
        typeof(IdentityServerDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IdentityServerDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IdentityServerDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerDemoApplicationModule).GetAssembly());
        }
    }
}