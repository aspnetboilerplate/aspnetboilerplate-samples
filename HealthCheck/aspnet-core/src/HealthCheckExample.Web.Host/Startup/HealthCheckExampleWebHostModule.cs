using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HealthCheckExample.Configuration;

namespace HealthCheckExample.Web.Host.Startup
{
    [DependsOn(
       typeof(HealthCheckExampleWebCoreModule))]
    public class HealthCheckExampleWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HealthCheckExampleWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HealthCheckExampleWebHostModule).GetAssembly());
        }
    }
}
