using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HealthCheckExample.Configuration;

namespace HealthCheckExample.Web.Startup
{
    [DependsOn(typeof(HealthCheckExampleWebCoreModule))]
    public class HealthCheckExampleWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HealthCheckExampleWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<HealthCheckExampleNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HealthCheckExampleWebMvcModule).GetAssembly());
        }
    }
}
