using System.Reflection;
using Abp.Modules;

namespace SimpleTaskSystem
{
    [DependsOn(typeof(SimpleTaskSystemCoreModule))]
    public class SimpleTaskSystemDataModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
