using System.Reflection;
using Abp.Modules;
using Abp.AutoMapper;

namespace AbpWpfDemo
{
    [DependsOn(typeof(AbpWpfDemoCoreModule),
        typeof(AbpAutoMapperModule))]
    public class AbpWpfDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
