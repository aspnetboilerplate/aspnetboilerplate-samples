using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using AbpjTable.People.Dto;
using AutoMapper;

namespace AbpjTable.People
{
    public class PersonAppService : AbpjTableAppServiceBase, IPersonAppService
    {
        private readonly IPersonRepository _personRepository;

        public PersonAppService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public PagedResultOutput<PersonDto> GetPeople(GetPeopleInput input)
        {
            var personListQuery = _personRepository.GetAllIncludingBirthCity();

            var totalCount = personListQuery.Count();
            var personList = personListQuery.OrderBy(p => p.Name)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToList();

            return new PagedResultOutput<PersonDto>
                   {
                       TotalCount = totalCount,
                       Items = Mapper.Map<List<PersonDto>>(personList)
                   };
        }
    }
}