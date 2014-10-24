using System.Reflection;
using Abp.Modules;

namespace AbpjTable
{
    public class AbpjTableCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
