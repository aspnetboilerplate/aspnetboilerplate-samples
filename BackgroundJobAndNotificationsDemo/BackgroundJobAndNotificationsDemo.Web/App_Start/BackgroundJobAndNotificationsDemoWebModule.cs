using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Modules;
using Abp.Web.Mvc;
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
        typeof(AbpHangfireModule))]
    public class BackgroundJobAndNotificationsDemoWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<BackgroundJobAndNotificationsDemoNavigationProvider>();

            Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage("Default"); //Set database connection
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
