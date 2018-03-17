using System.Threading.Tasks;
using Abp.Application.Services;
using Volo.SqliteDemo.Sessions.Dto;

namespace Volo.SqliteDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
