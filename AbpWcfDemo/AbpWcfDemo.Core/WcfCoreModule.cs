using System.Reflection;
using Abp.Modules;

namespace AbpWcfDemo
{
    public class WcfCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
