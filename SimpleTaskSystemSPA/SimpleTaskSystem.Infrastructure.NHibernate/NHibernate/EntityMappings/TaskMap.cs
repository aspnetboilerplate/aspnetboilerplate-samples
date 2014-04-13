using Abp.Domain.Entities.Mapping;
using SimpleTaskSystem.Tasks;

namespace SimpleTaskSystem.NHibernate.EntityMappings
{
public class TaskMap : EntityMap<Task, long>
{
    public TaskMap()
        : base("StsTasks")
    {
        Map(x => x.Description);
        Map(x => x.CreationTime);
        Map(x => x.State).CustomType<TaskState>();
        References(x => x.AssignedPerson).Column("AssignedPersonId").LazyLoad();
    }
}
}
