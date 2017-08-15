using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace AbpPerformanceTestApp
{
    [DependsOn(
        typeof(AbpPerformanceTestAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpPerformanceTestAppApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpPerformanceTestAppApplicationModule).GetAssembly());
        }
    }
}