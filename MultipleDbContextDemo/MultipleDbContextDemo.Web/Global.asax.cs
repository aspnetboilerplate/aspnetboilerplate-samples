using System;
using System.Globalization;
using System.Web;
using Abp.Castle.Logging.Log4Net;
using Abp.Configuration;
using Abp.Localization;
using Abp.Logging;
using Abp.Timing;
using Abp.Extensions;
using Abp.Web;
using Castle.Facilities.Logging;

namespace MultipleDbContextDemo.Web
{
    public class MvcApplication : AbpWebApplication<MultipleDbContextDemoWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer
                .AddFacility<LoggingFacility>(f => f.UseAbpLog4Net()
                    .WithConfig(Server.MapPath("log4net.config"))
                );
            
            base.Application_Start(sender, e);
        }
    }
}
