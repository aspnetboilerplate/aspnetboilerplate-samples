using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerDemo.Api.Configuration;
using IdentityServerDemo.Api.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace IdentityServerDemo.Api.Web.Startup
{
    [DependsOn(
        typeof(ApiApplicationModule), 
        typeof(ApiEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class ApiWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ApiWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(ApiConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<ApiNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(ApiApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ApiWebModule).GetAssembly());
        }
    }
}