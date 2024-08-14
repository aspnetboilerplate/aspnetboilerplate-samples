using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultipleDbContextEfCoreDemo.Configuration;

namespace MultipleDbContextEfCoreDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(MultipleDbContextEfCoreDemoWebCoreModule))]
    public class MultipleDbContextEfCoreDemoWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MultipleDbContextEfCoreDemoWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultipleDbContextEfCoreDemoWebHostModule).GetAssembly());
        }
    }
}
