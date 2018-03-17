using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Volo.PostgreSqlDemo.Configuration;

namespace Volo.PostgreSqlDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(PostgreSqlDemoWebCoreModule))]
    public class PostgreSqlDemoWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PostgreSqlDemoWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PostgreSqlDemoWebHostModule).GetAssembly());
        }
    }
}
