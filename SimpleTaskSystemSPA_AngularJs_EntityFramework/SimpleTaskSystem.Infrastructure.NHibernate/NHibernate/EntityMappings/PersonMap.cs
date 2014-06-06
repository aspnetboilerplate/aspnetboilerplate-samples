using Abp.Domain.Entities.Mapping;
using SimpleTaskSystem.People;

namespace SimpleTaskSystem.NHibernate.EntityMappings
{
    public class PersonMap : EntityMap<Person>
    {
        public PersonMap()
            : base("StsPeople")
        {
            Map(x => x.Name);
        }
    }
}
