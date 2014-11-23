using Abp.Application.Services;
using AbpWpfDemo.People.Dto;

namespace AbpWpfDemo.People
{
    public interface IPersonAppService : IApplicationService
    {
        GetPeopleOutput GetAllPeople();

        void AddNewPerson(AddNewPersonInput input);
    }
}