using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using InterceptionDemo.Configuration;

namespace InterceptionDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(InterceptionDemoWebCoreModule))]
    public class InterceptionDemoWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public InterceptionDemoWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InterceptionDemoWebHostModule).GetAssembly());
        }
    }
}
