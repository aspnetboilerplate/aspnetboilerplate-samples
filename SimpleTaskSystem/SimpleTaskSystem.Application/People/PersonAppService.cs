using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using SimpleTaskSystem.People.Dtos;

namespace SimpleTaskSystem.People
{
    public class PersonAppService : IPersonAppService //Optionally, you can derive from ApplicationService as we did for TaskAppService class.
    {
        private readonly IRepository<Person> _personRepository;

        //ABP provides that we can directly inject IRepository<Person> (without creating any repository class)
        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        //This method uses async pattern that is supported by ASP.NET Boilerplate
        public async Task<GetAllPeopleOutput> GetAllPeople()
        {
            var people = await _personRepository.GetAllListAsync();
            return new GetAllPeopleOutput
                   {
                       People = people.MapTo<List<PersonDto>>()
                   };
        }
    }
}