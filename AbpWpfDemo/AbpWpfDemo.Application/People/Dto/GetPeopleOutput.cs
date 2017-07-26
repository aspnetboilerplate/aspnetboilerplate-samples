using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace AbpWpfDemo.People.Dto
{
    public class GetPeopleOutput
    {
        public List<PersonDto> People { get; set; }
    }
}