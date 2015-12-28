using System.Reflection;
using Abp.Modules;

namespace AbpWpfDemo.UI_WinForms
{
    [DependsOn(typeof(AbpWpfDemoDataModule), typeof(AbpWpfDemoApplicationModule))]
    public class AbpWinFormsDemoUiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
