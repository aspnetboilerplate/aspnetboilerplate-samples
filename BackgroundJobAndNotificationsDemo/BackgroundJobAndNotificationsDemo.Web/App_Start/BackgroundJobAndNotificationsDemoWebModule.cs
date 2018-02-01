using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Web.Mvc;
using Abp.Web.SignalR;
using Abp.Zero.Configuration;
using BackgroundJobAndNotificationsDemo.Api;
using Hangfire;

namespace BackgroundJobAndNotificationsDemo.Web
{
    [DependsOn(
        typeof(BackgroundJobAndNotificationsDemoDataModule), 
        typeof(BackgroundJobAndNotificationsDemoApplicationModule), 
        typeof(BackgroundJobAndNotificationsDemoWebApiModule),
        typeof(AbpWebMvcModule),
        typeof(AbpWebSignalRModule), //Add AbpWebSignalRModule dependency
        typeof(AbpHangfireModule))] //Add AbpHangfireModule dependency
    public class BackgroundJobAndNotificationsDemoWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<BackgroundJobAndNotificationsDemoNavigationProvider>();

            //Configuration.BackgroundJobs.IsJobExecutionEnabled = false; //Can disable job manager to not process jobs.

            Configuration.BackgroundJobs.UseHangfire(configuration => //Configure to use hangfire for background jobs.
            {
                configuration.GlobalConfiguration.UseSqlServerStorage("Default"); //Set database connection
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackgroundJobAndNotificationsDemoWebModule).GetAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
