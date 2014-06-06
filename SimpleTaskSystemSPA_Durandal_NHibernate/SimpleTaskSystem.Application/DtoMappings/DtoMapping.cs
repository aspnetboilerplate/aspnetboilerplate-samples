using AutoMapper;
using SimpleTaskSystem.People;
using SimpleTaskSystem.People.Dtos;
using SimpleTaskSystem.Tasks;
using SimpleTaskSystem.Tasks.Dtos;

namespace SimpleTaskSystem.DtoMappings
{
    internal static class DtoMapping
    {
        public static void Map()
        {
            Mapper.CreateMap<Task, TaskDto>();
            Mapper.CreateMap<Person, PersonDto>();
        }
    }
}
