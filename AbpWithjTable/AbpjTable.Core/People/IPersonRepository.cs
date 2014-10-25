using System.Linq;
using Abp.Domain.Repositories;

namespace AbpjTable.People
{
    public interface IPersonRepository : IRepository<Person>
    {
        IQueryable<Person> GetAllIncludingBirthCity();
    }
}
