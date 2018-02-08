using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpKendoDemo.Configuration;

namespace AbpKendoDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpKendoDemoWebCoreModule))]
    public class AbpKendoDemoWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpKendoDemoWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpKendoDemoWebHostModule).GetAssembly());
        }
    }
}
