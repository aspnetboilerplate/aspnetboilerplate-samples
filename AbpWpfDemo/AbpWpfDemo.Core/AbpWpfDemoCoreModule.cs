using System.Reflection;
using Abp.Modules;

namespace AbpWpfDemo
{
    public class AbpWpfDemoCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
