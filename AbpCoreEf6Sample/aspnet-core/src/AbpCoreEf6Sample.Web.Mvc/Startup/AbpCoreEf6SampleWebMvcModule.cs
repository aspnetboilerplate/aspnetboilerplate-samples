using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreEf6Sample.Configuration;

namespace AbpCoreEf6Sample.Web.Startup
{
    [DependsOn(typeof(AbpCoreEf6SampleWebCoreModule))]
    public class AbpCoreEf6SampleWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpCoreEf6SampleWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<AbpCoreEf6SampleNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf6SampleWebMvcModule).GetAssembly());
        }
    }
}
