using System.Reflection;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerDemo.Api.Web.Startup;

namespace IdentityServerDemo.Api.Web.Tests
{
    [DependsOn(
        typeof(ApiWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class ApiWebTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ApiWebTestModule).GetAssembly());
        }
    }
}