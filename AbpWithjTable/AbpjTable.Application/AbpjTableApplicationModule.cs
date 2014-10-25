using System.Reflection;
using Abp.Modules;
using AbpjTable.People;
using AbpjTable.People.Dto;
using AutoMapper;

namespace AbpjTable
{
    [DependsOn(typeof(AbpjTableCoreModule))]
    public class AbpjTableApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Mapper.CreateMap<Person, PersonDto>();
        }
    }
}
