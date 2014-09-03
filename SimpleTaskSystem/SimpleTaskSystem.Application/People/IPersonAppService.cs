using Abp.Application.Services;
using SimpleTaskSystem.People.Dtos;

namespace SimpleTaskSystem.People
{
    public interface IPersonAppService : IApplicationService
    {
        GetAllPeopleOutput GetAllPeople();
    }
}
