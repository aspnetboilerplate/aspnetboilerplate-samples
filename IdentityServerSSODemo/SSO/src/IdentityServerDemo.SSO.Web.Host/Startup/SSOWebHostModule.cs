using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerDemo.SSO.Configuration;

namespace IdentityServerDemo.SSO.Web.Host.Startup
{
    [DependsOn(
       typeof(SSOWebCoreModule))]
    public class SSOWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SSOWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SSOWebHostModule).GetAssembly());
        }
    }
}
