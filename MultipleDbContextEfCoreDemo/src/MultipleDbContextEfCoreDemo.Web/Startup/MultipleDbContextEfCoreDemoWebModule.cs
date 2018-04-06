using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultipleDbContextEfCoreDemo.Configuration;
using MultipleDbContextEfCoreDemo.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MultipleDbContextEfCoreDemo.Web.Startup
{
    [DependsOn(
        typeof(MultipleDbContextEfCoreDemoApplicationModule), 
        typeof(MultipleDbContextEfCoreDemoEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class MultipleDbContextEfCoreDemoWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MultipleDbContextEfCoreDemoWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MultipleDbContextEfCoreDemoConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<MultipleDbContextEfCoreDemoNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MultipleDbContextEfCoreDemoApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultipleDbContextEfCoreDemoWebModule).GetAssembly());
        }
    }
}