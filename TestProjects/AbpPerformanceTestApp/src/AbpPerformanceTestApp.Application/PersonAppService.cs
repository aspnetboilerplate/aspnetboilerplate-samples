using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AbpPerformanceTestApp.Dto;

namespace AbpPerformanceTestApp
{
    public class PersonAppService : AbpPerformanceTestAppAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetPeople()
        {
            var persons = await _personRepository.GetAllListAsync();
            return new List<Person>(persons);
        }

        public async Task<int> InsertAndGetId(InsertAndGetIdInput input)
        {
            return await _personRepository.InsertAndGetIdAsync(new Person(){Name = input.Name,PhoneNumber = input.PhoneNumber});
        }

        public async Task Delete(EntityDto input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        public int GetConstant()
        {
            return 42;
        }
    }
}
