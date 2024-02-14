using System.Threading.Tasks;
using Abp.Application.Services;
using SimpleTaskSystem.Sessions.Dto;

namespace SimpleTaskSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
