using System.Windows;
using Abp;
using Abp.Castle.Logging.Log4Net;
using Castle.Facilities.Logging;

namespace AbpWpfDemo.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly AbpBootstrapper _bootstrapper;
        private MainWindow _mainWindow;

        public App()
        {
            _bootstrapper = AbpBootstrapper.Create<AbpWpfDemoUiModule>();
            _bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig("log4net.config"));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper.Initialize();

            _mainWindow = _bootstrapper.IocManager.Resolve<MainWindow>();
            _mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _bootstrapper.IocManager.Release(_mainWindow);
            _bootstrapper.Dispose();
        }
    }
}
