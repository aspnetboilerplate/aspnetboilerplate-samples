using System.Reflection;
using Abp.Modules;

namespace AbpjTable
{
    [DependsOn(typeof(AbpjTableCoreModule))]
    public class AbpjTableApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
