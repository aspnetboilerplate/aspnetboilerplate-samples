using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MultipleDbContextEfCoreDemo
{
    [DependsOn(
        typeof(MultipleDbContextEfCoreDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MultipleDbContextEfCoreDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultipleDbContextEfCoreDemoApplicationModule).GetAssembly());
        }
    }
}