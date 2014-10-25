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
            var personListQuery = _personRepository.GetAll();

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

        public CreatePersonOutput CreatePerson(CreatePersonInput input)
        {
            var person = Mapper.Map<Person>(input);

            _personRepository.InsertAndGetId(person);

            return new CreatePersonOutput
                   {
                       Person = Mapper.Map<PersonDto>(person)
                   };
        }
    }
}