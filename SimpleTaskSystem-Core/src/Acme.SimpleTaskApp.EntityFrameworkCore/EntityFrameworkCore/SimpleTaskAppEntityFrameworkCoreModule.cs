using System.Reflection;
using Abp.EntityFrameworkCore;
using Abp.Modules;

namespace Acme.SimpleTaskApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(SimpleTaskAppCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class SimpleTaskAppEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}