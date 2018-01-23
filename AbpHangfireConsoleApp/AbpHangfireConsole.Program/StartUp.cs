using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AbpHangfireConsoleApp.Startup))]

namespace AbpHangfireConsoleApp
{
    /// <summary>
    ///     Class to manage access to the hangfire dashboard.
    /// </summary>
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        /// <summary>
        ///     Determines whether a user may access the hangfire dashboard.
        /// </summary>
        /// <param name="aContext">Context we are accessing the dashboard in.</param>
        /// <returns>Returns TRUE should the user be allowed to access the dashboard.</returns>
        public bool Authorize(DashboardContext aContext)
        {
            // In case you need an OWIN context, use the next line, `OwinContext` class
            // is the part of the `Microsoft.Owin` package.
            OwinContext owinContext = new OwinContext(aContext.GetOwinEnvironment());

            return true;
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("default")
                .UseConsole(new ConsoleOptions
                {
                    BackgroundColor = "#0d3163",
                    TextColor = "#ffffff",
                    TimestampColor = "#00aad7"
                });

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                AppPath = "/",
                Authorization = new[]
                {
                    new HangfireAuthorizationFilter()
                }
            });

            BackgroundJobServerOptions serverOptions = new BackgroundJobServerOptions
            {
            };

            app.UseHangfireServer(serverOptions);        }
    }
}