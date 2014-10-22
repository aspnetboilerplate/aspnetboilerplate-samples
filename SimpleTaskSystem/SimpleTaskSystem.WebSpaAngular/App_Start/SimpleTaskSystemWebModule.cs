using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Sources.Xml;
using Abp.Modules;

namespace SimpleTaskSystem.WebSpaAngular
{
    [DependsOn(typeof(SimpleTaskSystemDataModule), typeof(SimpleTaskSystemWebApiModule))]
    public class SimpleTaskSystemWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<SimpleTaskSystemNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Localization.Sources.Add(
                new XmlLocalizationSource(
                    "SimpleTaskSystem",
                    HttpContext.Current.Server.MapPath("~/Localization/SimpleTaskSystem")
                    )
                );

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
