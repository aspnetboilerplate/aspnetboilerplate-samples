using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SimpleTaskSystem.Configuration;

namespace SimpleTaskSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(SimpleTaskSystemWebCoreModule))]
    public class SimpleTaskSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SimpleTaskSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskSystemWebHostModule).GetAssembly());
        }
    }
}
