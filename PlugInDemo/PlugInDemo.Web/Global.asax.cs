using System;
using System.Web;
using Abp.PlugIns;
using Abp.Web;
using Castle.Facilities.Logging;

namespace PlugInDemo.Web
{
    public class MvcApplication : AbpWebApplication<PlugInDemoWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            //Configure plugins
            AbpBootstrapper
                .PlugInSources
                .AddFolder(HttpContext.Current.Server.MapPath("~/PlugIns"));

            //Configure logging
            AbpBootstrapper.IocManager
                .IocContainer
                .AddFacility<LoggingFacility>(f => f.UseLog4Net()
                .WithConfig("log4net.config"));

            base.Application_Start(sender, e);
        }
    }
}
