using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpPerformanceTestApp.Configuration;
using AbpPerformanceTestApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AbpPerformanceTestApp.Web.Startup
{
    [DependsOn(
        typeof(AbpPerformanceTestAppApplicationModule), 
        typeof(AbpPerformanceTestAppEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class AbpPerformanceTestAppWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpPerformanceTestAppWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(AbpPerformanceTestAppConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<AbpPerformanceTestAppNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(AbpPerformanceTestAppApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpPerformanceTestAppWebModule).GetAssembly());
        }
    }
}