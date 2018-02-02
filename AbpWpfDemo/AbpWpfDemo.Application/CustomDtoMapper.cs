using AbpWpfDemo.People;
using AbpWpfDemo.People.Dto;
using AutoMapper;

namespace AbpWpfDemo
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Inputs
            configuration.CreateMap<Person, PersonDto>();
        }
    }
}