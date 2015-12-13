using System.Reflection;
using Abp.Modules;

namespace MultipleDbContextDemo
{
    [DependsOn(typeof(MultipleDbContextDemoCoreModule))]
    public class MultipleDbContextDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
