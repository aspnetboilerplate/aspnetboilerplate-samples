using System.Threading.Tasks;
using Abp.Application.Services;
using Volo.PostgreSqlDemo.Sessions.Dto;

namespace Volo.PostgreSqlDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
