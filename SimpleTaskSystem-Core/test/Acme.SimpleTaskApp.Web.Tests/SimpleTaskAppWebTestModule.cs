using System.Reflection;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Acme.SimpleTaskApp.Web.Startup;

namespace Acme.SimpleTaskApp.Web.Tests
{
    [DependsOn(
        typeof(SimpleTaskAppWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class SimpleTaskAppWebTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}