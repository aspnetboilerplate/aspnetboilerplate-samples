using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServervNextDemo.Configuration;

namespace IdentityServervNextDemo.Web.Startup
{
    [DependsOn(typeof(IdentityServervNextDemoWebCoreModule))]
    public class IdentityServervNextDemoWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IdentityServervNextDemoWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<IdentityServervNextDemoNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServervNextDemoWebMvcModule).GetAssembly());
        }
    }
}
