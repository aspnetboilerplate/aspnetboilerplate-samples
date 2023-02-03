using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreEf7JsonColumnDemo.Configuration;

namespace AbpCoreEf7JsonColumnDemo.Web.Startup
{
    [DependsOn(typeof(AbpCoreEf7JsonColumnDemoWebCoreModule))]
    public class AbpCoreEf7JsonColumnDemoWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpCoreEf7JsonColumnDemoWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<AbpCoreEf7JsonColumnDemoNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf7JsonColumnDemoWebMvcModule).GetAssembly());
        }
    }
}
