using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using AbpKendoDemo.Configuration;
using AbpKendoDemo.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Zero.Configuration;

namespace AbpKendoDemo.Web.Startup
{
    [DependsOn(
        typeof(AbpKendoDemoApplicationModule), 
        typeof(AbpKendoDemoEntityFrameworkModule), 
        typeof(AbpAspNetCoreModule))]
    public class AbpKendoDemoWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpKendoDemoWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(AbpKendoDemoConsts.ConnectionStringName);

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Navigation.Providers.Add<AbpKendoDemoNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(AbpKendoDemoApplicationModule).Assembly
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}