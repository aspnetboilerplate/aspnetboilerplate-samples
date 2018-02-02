using System;
using System.Net;
using System.Text;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Caching.Redis;
using Abp.Threading;
using Abp.Zero.Configuration;
using Acme.ProjectName.Authentication.JwtBearer;
using Acme.ProjectName.Configuration;
using Acme.ProjectName.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

#if FEATURE_SIGNALR
using Abp.Web.SignalR;
#endif

namespace Acme.ProjectName
{
    [DependsOn(
         typeof(ProjectNameApplicationModule),
         typeof(ProjectNameEntityFrameworkModule),
         typeof(AbpAspNetCoreModule),
        typeof(AbpRedisCacheModule)
#if FEATURE_SIGNALR 
        ,typeof(AbpWebSignalRModule)
#endif
     )]
    public class ProjectNameWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ProjectNameWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ProjectNameConsts.ConnectionStringName
            );

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(ProjectNameApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();

            Configuration.Caching.UseRedis(options =>
            {
                var connectionString = _appConfiguration["Abp:RedisCache:ConnectionString"];
                if (connectionString != null && connectionString != "localhost")
                {
                    options.ConnectionString = AsyncHelper.RunSync(() => Dns.GetHostAddressesAsync(connectionString))[0].ToString();
                }
            });
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProjectNameWebCoreModule).GetAssembly());
        }
    }
}
