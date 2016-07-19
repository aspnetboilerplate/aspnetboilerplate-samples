using System;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;

namespace SimpleTaskSystem.WebSpaDurandal
{
    public class MvcApplication : AbpWebApplication<SimpleTaskSystemWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
    }
}
