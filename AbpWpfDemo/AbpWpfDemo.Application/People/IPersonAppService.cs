using System.Threading.Tasks;
using Abp.Application.Services;
using AbpWpfDemo.People.Dto;

namespace AbpWpfDemo.People
{
    public interface IPersonAppService : IApplicationService
    {
        Task<GetPeopleOutput> GetAllPeopleAsync();

        Task AddNewPerson(AddNewPersonInput input);
    }
}