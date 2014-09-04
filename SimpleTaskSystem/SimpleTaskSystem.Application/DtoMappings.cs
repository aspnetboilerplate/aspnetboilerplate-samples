using AutoMapper;
using SimpleTaskSystem.People;
using SimpleTaskSystem.People.Dtos;
using SimpleTaskSystem.Tasks;
using SimpleTaskSystem.Tasks.Dtos;

namespace SimpleTaskSystem
{
    internal static class DtoMappings
    {
        public static void Map()
        {
            //This code configures AutoMapper to auto map between Entities and DTOs.

            Mapper.CreateMap<Task, TaskDto>();
            Mapper.CreateMap<Person, PersonDto>();
        }
    }
}
