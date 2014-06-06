using System.Reflection;
using Abp.Dependency;
using Abp.Modules;
using Abp.Startup;

namespace SimpleTaskSystem
{
    public class SimpleTaskSystemCoreModule : AbpModule
    {
        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
