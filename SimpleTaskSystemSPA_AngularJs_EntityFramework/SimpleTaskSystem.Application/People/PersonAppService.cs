using System.Collections.Generic;
using Abp.Application.Services;
using AutoMapper;
using SimpleTaskSystem.People.Dtos;

namespace SimpleTaskSystem.People
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        private readonly IPersonRepository _personRepository;

        public PersonAppService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public GetAllPeopleOutput GetAllPeople()
        {
            return new GetAllPeopleOutput
                   {
                       People = Mapper.Map<List<PersonDto>>(_personRepository.GetAllList())
                   };
        }
    }
}