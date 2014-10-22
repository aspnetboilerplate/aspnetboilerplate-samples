using Abp.NHibernate.EntityMappings;
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
