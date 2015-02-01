using AutoMapper;
using SimpleTaskSystem.Tasks;
using SimpleTaskSystem.Tasks.Dtos;

namespace SimpleTaskSystem
{
    internal static class DtoMappings
    {
        public static void Map()
        {
            //I specified mapping for AssignedPersonId since NHibernate does not fill Task.AssignedPersonId
            //If you will just use EF, then you can remove ForMember definition.
            Mapper.CreateMap<Task, TaskDto>().ForMember(t => t.AssignedPersonId, opts => opts.MapFrom(d => d.AssignedPerson.Id));
        }
    }
}
