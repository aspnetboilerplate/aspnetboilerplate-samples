using System.Windows;
using Abp;
using Abp.Dependency;
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
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            _bootstrapper = new AbpBootstrapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper.Initialize();

            _mainWindow = IocManager.Instance.Resolve<MainWindow>();
            _mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            IocManager.Instance.Release(_mainWindow);
            _bootstrapper.Dispose();
        }
    }
}
