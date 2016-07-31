using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Acme.SimpleTaskApp.Configuration;
using Acme.SimpleTaskApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Acme.SimpleTaskApp.Web.Startup
{
    [DependsOn(
        typeof(SimpleTaskAppApplicationModule), 
        typeof(SimpleTaskAppEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class SimpleTaskAppWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public SimpleTaskAppWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SimpleTaskAppConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<SimpleTaskAppNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(SimpleTaskAppApplicationModule).Assembly
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}