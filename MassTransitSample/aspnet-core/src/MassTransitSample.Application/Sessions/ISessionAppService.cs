using System.Threading.Tasks;
using Abp.Application.Services;
using MassTransitSample.Sessions.Dto;

namespace MassTransitSample.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
