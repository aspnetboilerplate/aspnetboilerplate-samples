using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Abp.Dependency;
using Abp.Localization;
using Abp.Modules;
using Abp.Startup;
using SimpleTaskSystem.WebSpaDurandal.Localization.SimpleTaskSystem;

namespace SimpleTaskSystem.WebSpaDurandal
{
    public class SimpleTaskSystemWebModule : AbpModule
    {
        public override Type[] GetDependedModules()
        {
            return new[]
                   {
                       typeof(SimpleTaskSystemNHibernateModule),
                       typeof(SimpleTaskSystemWebApiModule)
                   };
        }

        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            LocalizationHelper.RegisterSource<SimpleTaskSystemLocalizationSource>();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
