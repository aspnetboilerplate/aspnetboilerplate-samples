using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AutoMapper;

namespace AbpPerformanceTestApp
{
    public class PersonAppService : AbpPerformanceTestAppAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<ListResultDto<PersonListDto>> GetPeople(GetPeopleInput input)
        {
            var persons = await _personRepository.GetAllListAsync();
            return new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(persons.ToList()));
        }

        public async Task<int> InsertAndGetId(InsertAndGetIdInput input)
        {
            var returnId = await _personRepository.InsertAndGetIdAsync(new Person(){Name = input.Name,PhoneNumber = input.PhoneNumber});
            return returnId;
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
