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

            //I specified mapping for AssignedPersonId since NHibernate does not fill Task.AssignedPersonId
            //If you will just use EF, then you can remove ForMember definition.
            Mapper.CreateMap<Task, TaskDto>().ForMember(t => t.AssignedPersonId, opts => opts.MapFrom(d => d.AssignedPerson.Id));
            
            Mapper.CreateMap<Person, PersonDto>();
        }
    }
}
