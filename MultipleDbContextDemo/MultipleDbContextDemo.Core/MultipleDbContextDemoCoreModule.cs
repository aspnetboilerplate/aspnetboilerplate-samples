using System.Reflection;
using Abp.Modules;

namespace MultipleDbContextDemo
{
    public class MultipleDbContextDemoCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
