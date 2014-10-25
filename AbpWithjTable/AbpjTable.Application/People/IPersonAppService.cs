using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpjTable.People.Dto;

namespace AbpjTable.People
{
    public interface IPersonAppService : IApplicationService    
    {
        PagedResultOutput<PersonDto> GetPeople(GetPeopleInput input);
    }
}
