using System.Threading.Tasks;
using Abp.Application.Services;
using MultipleDbContextEfCoreDemo.Sessions.Dto;

namespace MultipleDbContextEfCoreDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
