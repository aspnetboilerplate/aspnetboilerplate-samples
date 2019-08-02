using System.Threading.Tasks;
using Abp.Application.Services;
using HealthCheckExample.Sessions.Dto;

namespace HealthCheckExample.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
