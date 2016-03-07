using System;
using System.Web;
using Abp.Reflection;
using Abp.Web;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;

namespace PlugInDemo.Web
{
    public class MvcApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.Register(
                Component.For<IAssemblyFinder>().UsingFactoryMethod(
                    () => new MultiSourceAssemblyFinder(
                        new WebAssemblyFinder(),
                        new FolderAssemblyFinder(HttpContext.Current.Server.MapPath("~/PlugIns"))
                        )
                    )
                );

            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
    }
}
