using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using AbpWpfDemo.People.Dto;
using AutoMapper;
using Castle.Core.Logging;

namespace AbpWpfDemo.People
{
    public class PersonAppService : AbpWpfDemoAppServiceBase, IPersonAppService
    {
        public new ILogger Logger { get; set; }

        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            Logger = NullLogger.Instance;
        }

        public async Task<GetPeopleOutput> GetAllPeopleAsync()
        {
            Logger.Debug("Getting all people");

            return new GetPeopleOutput
                   {
                       People = Mapper.Map<List<PersonDto>>(await _personRepository.GetAllListAsync())
                   };
        }

        public async Task AddNewPerson(AddNewPersonInput input)
        {
            Logger.Debug("Adding a new person: " + input.Name);
            await _personRepository.InsertAsync(new Person { Name = input.Name });
        }
    }
}
