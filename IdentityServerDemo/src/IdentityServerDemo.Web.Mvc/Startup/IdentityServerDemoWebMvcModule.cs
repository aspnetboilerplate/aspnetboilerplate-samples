using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerDemo.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace IdentityServerDemo.Web.Startup
{
    [DependsOn(typeof(IdentityServerDemoWebCoreModule))]
    public class IdentityServerDemoWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IdentityServerDemoWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<IdentityServerDemoNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerDemoWebMvcModule).GetAssembly());
        }
    }
}