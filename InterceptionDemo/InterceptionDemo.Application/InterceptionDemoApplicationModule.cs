using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace InterceptionDemo
{
    [DependsOn(typeof(InterceptionDemoCoreModule), typeof(AbpAutoMapperModule))]
    public class InterceptionDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
