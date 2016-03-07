using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace PlugInDemo
{
    [DependsOn(typeof(PlugInDemoCoreModule), typeof(AbpAutoMapperModule))]
    public class PlugInDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
