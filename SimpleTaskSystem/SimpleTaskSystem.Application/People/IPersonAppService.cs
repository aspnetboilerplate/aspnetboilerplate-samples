using System.Threading.Tasks;
using Abp.Application.Services;
using SimpleTaskSystem.People.Dtos;

namespace SimpleTaskSystem.People
{
    public interface IPersonAppService : IApplicationService
    {
        Task<GetAllPeopleOutput> GetAllPeople();
    }
}
