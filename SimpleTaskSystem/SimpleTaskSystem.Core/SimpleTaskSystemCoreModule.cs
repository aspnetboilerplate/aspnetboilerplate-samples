using System.Reflection;
using Abp.Dependency;
using Abp.Modules;
using Abp.Startup;

namespace SimpleTaskSystem
{
    /// <summary>
    /// 'Core module' for this project.
    /// </summary>
    public class SimpleTaskSystemCoreModule : AbpModule
    {
        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);

            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
