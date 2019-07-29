using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;
using AbpWcfDemo;

namespace AbpWcfDemo.Web
{
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(WcfDataModule), 
        typeof(WcfApplicationModule), 
        typeof(WcfWebApiModule),
        typeof(WcfSoapModule)       // GP: added by me for SOAP
        )]
    public class WcfWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-gb", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
            Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "简体中文", "famfamfam-flag-cn"));
            Configuration.Localization.Languages.Add(new LanguageInfo("ja", "日本語", "famfamfam-flag-jp"));

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    WcfConsts.LocalizationSourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        HttpContext.Current.Server.MapPath("~/Localization/Soap")
                        )
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<WcfNavigationProvider>();
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
