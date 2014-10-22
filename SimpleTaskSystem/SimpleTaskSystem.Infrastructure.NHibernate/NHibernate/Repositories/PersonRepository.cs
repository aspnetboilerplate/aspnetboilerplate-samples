using Abp.NHibernate.Repositories;
using SimpleTaskSystem.People;

namespace SimpleTaskSystem.NHibernate.Repositories
{
    public class PersonRepository : NhRepositoryBase<Person>, IPersonRepository
    {
        //Since IPersonRepository does not define additional methods, this class's body is empty for now.
    }
}