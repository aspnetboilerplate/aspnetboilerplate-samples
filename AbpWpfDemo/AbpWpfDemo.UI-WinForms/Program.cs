using System;
using System.Windows.Forms;
using Abp;
using Abp.Castle.Logging.Log4Net;
using Castle.Facilities.Logging;

namespace AbpWpfDemo.UI_WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var bootstrapper = AbpBootstrapper.Create<AbpWinFormsDemoUiModule>())
            {
                bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig("log4net.config"));
                
                bootstrapper.Initialize();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(bootstrapper.IocManager.Resolve<MainForm>());
            }
        }
    }
}
