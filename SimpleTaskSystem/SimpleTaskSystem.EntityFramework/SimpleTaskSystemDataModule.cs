using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;

namespace SimpleTaskSystem
{
    [DependsOn(typeof(SimpleTaskSystemCoreModule), typeof(AbpEntityFrameworkModule))]
    public class SimpleTaskSystemDataModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
