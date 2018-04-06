using System;
using System.IO;
using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Modules;
using AbpHangfireConsole.Hangfire.Jobs.GetServers;
using AbpHangfireConsole.Hangfire.Jobs.GetServers.Dtos;
using Castle.Facilities.Logging;
using Hangfire;

namespace AbpHangfireConsoleApp
{
    public sealed class AbpHangfireConsoleApplication<TStartupModule> where TStartupModule : AbpModule
    {
        /// <summary>
        ///     Gets a reference to the <see cref="AbpBootstrapper" /> instance.
        /// </summary>
        public static AbpBootstrapper AbpBootstrapper { get; } = AbpBootstrapper.Create<TStartupModule>();


        public void Application_Start()
        {
            AbpBootstrapper.Initialize();

            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig($"{GetAppPath()}log4net.config")
            );
        }

        private static string GetAppPath()
        {
            string appPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            if (!appPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                appPath += Path.DirectorySeparatorChar;
            return appPath;
        }

        public void Application_End()
        {
            AbpBootstrapper.Dispose();
        }
    }
}