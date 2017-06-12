using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerDemo.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace IdentityServerDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(IdentityServerDemoWebCoreModule))]
    public class IdentityServerDemoWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IdentityServerDemoWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerDemoWebHostModule).GetAssembly());
        }
    }
}
