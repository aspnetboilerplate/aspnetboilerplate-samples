using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AbpjTable.People.Dto;
using AutoMapper;

namespace AbpjTable.People
{
    public class PersonAppService : AbpjTableAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public PagedResultOutput<PersonDto> GetPeople(GetPeopleInput input)
        {
            var personListQuery = _personRepository.GetAll()
                .OrderBy(p => p.Name)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            return new PagedResultOutput<PersonDto>
                   {
                       TotalCount = personListQuery.Count(),
                       Items = Mapper.Map<List<PersonDto>>(personListQuery.ToList())
                   };
        }
    }
}