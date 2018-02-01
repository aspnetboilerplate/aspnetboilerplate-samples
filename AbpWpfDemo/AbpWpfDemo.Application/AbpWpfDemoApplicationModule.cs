using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using AbpWpfDemo.People;
using AbpWpfDemo.People.Dto;

namespace AbpWpfDemo
{
    [DependsOn(typeof(AbpWpfDemoCoreModule), typeof(AbpAutoMapperModule))]
    public class AbpWpfDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            config.CreateMap<Person, PersonDto>()
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
