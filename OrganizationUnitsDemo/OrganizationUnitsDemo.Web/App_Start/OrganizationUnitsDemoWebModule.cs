using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Zero.Configuration;
using OrganizationUnitsDemo.Api;

namespace OrganizationUnitsDemo.Web
{
    [DependsOn(
        typeof(OrganizationUnitsDemoDataModule), 
        typeof(OrganizationUnitsDemoApplicationModule), 
        typeof(OrganizationUnitsDemoWebApiModule),
        typeof(AbpWebMvcModule))]
    public class OrganizationUnitsDemoWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<OrganizationUnitsDemoNavigationProvider>();
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
