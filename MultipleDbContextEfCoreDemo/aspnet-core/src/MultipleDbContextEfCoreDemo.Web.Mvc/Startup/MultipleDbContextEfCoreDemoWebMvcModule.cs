using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultipleDbContextEfCoreDemo.Configuration;

namespace MultipleDbContextEfCoreDemo.Web.Startup
{
    [DependsOn(typeof(MultipleDbContextEfCoreDemoWebCoreModule))]
    public class MultipleDbContextEfCoreDemoWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MultipleDbContextEfCoreDemoWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<MultipleDbContextEfCoreDemoNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultipleDbContextEfCoreDemoWebMvcModule).GetAssembly());
        }
    }
}
