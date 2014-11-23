using System.Reflection;
using Abp.Modules;

namespace AbpWpfDemo.UI
{
    [DependsOn(typeof(AbpWpfDemoDataModule), typeof(AbpWpfDemoApplicationModule))]
    public class AbpWpfDemoUiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
