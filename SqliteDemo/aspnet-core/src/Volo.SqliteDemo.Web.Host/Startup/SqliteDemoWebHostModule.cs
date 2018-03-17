using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Volo.SqliteDemo.Configuration;

namespace Volo.SqliteDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(SqliteDemoWebCoreModule))]
    public class SqliteDemoWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SqliteDemoWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SqliteDemoWebHostModule).GetAssembly());
        }
    }
}
