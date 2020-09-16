using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.AspNetCore.Mvc.Antiforgery;
using Abp.Castle.Logging.Log4Net;
using IdentityServerWithEfCoreDemo.Authentication.JwtBearer;
using IdentityServerWithEfCoreDemo.Configuration;
using IdentityServerWithEfCoreDemo.Identity;
using IdentityServerWithEfCoreDemo.Web.Resources;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Dependency;
using Abp.Json;
using IdentityServer4.EntityFramework;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Services;
using IdentityServer4.EntityFramework.Stores;
using IdentityServer4.Stores;
using IdentityServerWithEfCoreDemo.Authorization.Users;
using IdentityServerWithEfCoreDemo.EntityFrameworkCore;
using IdentityServerWithEfCoreDemo.EntityFrameworkCore.IdentityServer;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;


namespace IdentityServerWithEfCoreDemo.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IWebHostEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddControllersWithViews(
                    options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                        options.Filters.Add(new AbpAutoValidateAntiforgeryTokenAttribute());
                    }
                )
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new AbpMvcContractResolver(IocManager.Instance)
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                });

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            // Identity Server
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddClientStore<ClientStore>()
                .AddResourceStore<ResourceStore>()
                .AddCorsPolicyService<CorsPolicyService>()
                .AddAbpIdentityServer<User>();

            services.AddSingleton(IdentityServerStoreOptionsProvider.Instance.ConfigurationStoreOptions);
            services.AddSingleton(IdentityServerStoreOptionsProvider.Instance.OperationalStoreOptions);
            services.AddScoped<IConfigurationDbContext>(provider =>
                provider.GetRequiredService<IdentityServerDbContextProvider>()
                    .GetDbContext<IdentityServerWithEfCoreDemoDbContext>());
            services.AddScoped<IPersistedGrantDbContext>(provider =>
                provider.GetRequiredService<IdentityServerDbContextProvider>()
                    .GetDbContext<IdentityServerWithEfCoreDemoDbContext>());

            services.AddTransient<TokenCleanupService>();
            services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();
            services.AddTransient<IDeviceFlowStore, DeviceFlowStore>();
            services.AddSingleton<IHostedService, TokenCleanupHost>();


            services.AddScoped<IWebResourceManager, WebResourceManager>();

            services.AddSignalR();

            // Configure Abp and Dependency Injection
            return services.AddAbp<IdentityServerWithEfCoreDemoWebMvcModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseJwtTokenMiddleware("IdentityBearer");
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AbpCommonHub>("/signalr");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
