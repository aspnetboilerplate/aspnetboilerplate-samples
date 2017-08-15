using System.Reflection;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpPerformanceTestApp.Web.Startup;

namespace AbpPerformanceTestApp.Web.Tests
{
    [DependsOn(
        typeof(AbpPerformanceTestAppWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class AbpPerformanceTestAppWebTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpPerformanceTestAppWebTestModule).GetAssembly());
        }
    }
}