using System.Collections.Generic;
using Abp.Domain.Repositories;
using AbpWpfDemo.People.Dto;
using AutoMapper;

namespace AbpWpfDemo.People
{
    public class PersonAppService : AbpWpfDemoAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public GetPeopleOutput GetAllPeople()
        {
            return new GetPeopleOutput
                   {
                       People = Mapper.Map<List<PersonDto>>(_personRepository.GetAll())
                   };
        }

        public void AddNewPerson(AddNewPersonInput input)
        {
            _personRepository.Insert(new Person {Name = input.Name});
        }
    }
}
