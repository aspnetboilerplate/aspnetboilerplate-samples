using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreEf6Sample.Configuration;

namespace AbpCoreEf6Sample.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpCoreEf6SampleWebCoreModule))]
    public class AbpCoreEf6SampleWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpCoreEf6SampleWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf6SampleWebHostModule).GetAssembly());
        }
    }
}
