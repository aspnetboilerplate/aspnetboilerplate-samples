using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.MySqlDemo.Configuration;

namespace Acme.MySqlDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(MySqlDemoWebCoreModule))]
    public class MySqlDemoWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MySqlDemoWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MySqlDemoWebHostModule).GetAssembly());
        }
    }
}
