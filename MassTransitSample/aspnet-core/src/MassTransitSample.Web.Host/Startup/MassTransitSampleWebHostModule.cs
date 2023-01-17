using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MassTransitSample.Configuration;

namespace MassTransitSample.Web.Host.Startup
{
    [DependsOn(
       typeof(MassTransitSampleWebCoreModule))]
    public class MassTransitSampleWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MassTransitSampleWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MassTransitSampleWebHostModule).GetAssembly());
        }
    }
}
