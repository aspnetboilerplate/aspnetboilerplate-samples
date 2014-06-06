using Abp.Application.Services.Dto;

namespace SimpleTaskSystem.People.Dtos
{
    public class PersonDto : EntityDto
    {
        public string Name { get; set; }
    }
}