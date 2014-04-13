using Abp.Domain.Repositories.NHibernate;
using SimpleTaskSystem.People;

namespace SimpleTaskSystem.NHibernate.Repositories
{
    public class PersonRepository : NhRepositoryBase<Person>, IPersonRepository
    {

    }
}