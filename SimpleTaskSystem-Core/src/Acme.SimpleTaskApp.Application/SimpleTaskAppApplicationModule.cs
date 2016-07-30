using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Acme.SimpleTaskApp
{
    [DependsOn(
        typeof(SimpleTaskAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SimpleTaskAppApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}