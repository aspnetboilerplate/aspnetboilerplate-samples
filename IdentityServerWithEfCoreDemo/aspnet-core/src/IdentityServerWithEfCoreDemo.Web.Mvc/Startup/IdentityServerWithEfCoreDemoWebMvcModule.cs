using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerWithEfCoreDemo.Configuration;

namespace IdentityServerWithEfCoreDemo.Web.Startup
{
    [DependsOn(typeof(IdentityServerWithEfCoreDemoWebCoreModule))]
    public class IdentityServerWithEfCoreDemoWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IdentityServerWithEfCoreDemoWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<IdentityServerWithEfCoreDemoNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerWithEfCoreDemoWebMvcModule).GetAssembly());
        }
    }
}
