using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreEf7JsonColumnDemo.Configuration;

namespace AbpCoreEf7JsonColumnDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpCoreEf7JsonColumnDemoWebCoreModule))]
    public class AbpCoreEf7JsonColumnDemoWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpCoreEf7JsonColumnDemoWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf7JsonColumnDemoWebHostModule).GetAssembly());
        }
    }
}
