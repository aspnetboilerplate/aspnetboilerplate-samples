using System;
using System.Windows.Forms;
using Abp;
using Castle.Facilities.Logging;

namespace AbpWpfDemo.UI_WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var bootstrapper = new AbpBootstrapper())
            {
                bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
                
                bootstrapper.Initialize();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(bootstrapper.IocManager.Resolve<MainForm>());
            }
        }
    }
}
