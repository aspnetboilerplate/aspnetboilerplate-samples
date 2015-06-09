using System.Reflection;
using Abp.Modules;

namespace SimpleTaskSystem.ConsoleApp
{
    [DependsOn(typeof(SimpleTaskSystemDataModule), typeof(SimpleTaskSystemApplicationModule))]
    public class SimpleTaskSystemConsoleAppModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}