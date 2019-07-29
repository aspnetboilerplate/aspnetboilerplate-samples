using System.Reflection;
using Abp.Modules;

namespace AbpWcfDemo
{
    [DependsOn(typeof(WcfCoreModule))]
    public class WcfApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
