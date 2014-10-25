using Abp.Application.Services.Dto;

namespace AbpjTable.People.Dto
{
    public class CreatePersonOutput : IOutputDto
    {
        public PersonDto Person { get; set; }
    }
}