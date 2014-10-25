using System.Data.Entity;
using System.Linq;
using AbpjTable.People;

namespace AbpjTable.EntityFramework.Repositories
{
    internal class PersonRepository : AbpjTableRepositoryBase<Person>, IPersonRepository
    {
        public IQueryable<Person> GetAllIncludingBirthCity()
        {
            return GetAll().Include(p => p.BirthCity);
        }
    }
}