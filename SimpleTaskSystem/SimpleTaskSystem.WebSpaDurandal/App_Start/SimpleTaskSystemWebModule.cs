using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Abp.Localization.Sources.Xml;
using Abp.Modules;

namespace SimpleTaskSystem.WebSpaDurandal
{
    [DependsOn(typeof(SimpleTaskSystemDataModule), typeof(SimpleTaskSystemWebApiModule))]
    public class SimpleTaskSystemWebModule : AbpModule
    {
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
        }
    }
}
