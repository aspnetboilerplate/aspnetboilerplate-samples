using System.Reflection;
using Abp.Modules;
using AbpWpfDemo.People;
using AbpWpfDemo.People.Dto;
using AutoMapper;

namespace AbpWpfDemo
{
    [DependsOn(typeof(AbpWpfDemoCoreModule))]
    public class AbpWpfDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Mapper.CreateMap<Person, PersonDto>();
        }
    }
}
