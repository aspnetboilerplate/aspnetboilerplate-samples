using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;

namespace SimpleTaskSystem.WebSpaAngular
{
    public class MvcApplication : AbpWebApplication<SimpleTaskSystemWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig(Server.MapPath("~/log4net.config")));
            base.Application_Start(sender, e);
        }
    }
}
