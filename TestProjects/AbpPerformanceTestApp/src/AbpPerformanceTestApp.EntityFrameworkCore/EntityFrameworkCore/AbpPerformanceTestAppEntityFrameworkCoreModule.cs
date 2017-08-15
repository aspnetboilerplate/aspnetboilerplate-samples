using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace AbpPerformanceTestApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpPerformanceTestAppCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class AbpPerformanceTestAppEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpPerformanceTestAppEntityFrameworkCoreModule).GetAssembly());
        }
    }
}