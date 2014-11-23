using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace AbpWpfDemo.People.Dto
{
    public class GetPeopleOutput : IOutputDto
    {
        public List<PersonDto> People { get; set; }
    }
}