using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Volo.PostgreSqlDemo.Configuration;

namespace Volo.PostgreSqlDemo.Web.Startup
{
    [DependsOn(typeof(PostgreSqlDemoWebCoreModule))]
    public class PostgreSqlDemoWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PostgreSqlDemoWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<PostgreSqlDemoNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PostgreSqlDemoWebMvcModule).GetAssembly());
        }
    }
}
