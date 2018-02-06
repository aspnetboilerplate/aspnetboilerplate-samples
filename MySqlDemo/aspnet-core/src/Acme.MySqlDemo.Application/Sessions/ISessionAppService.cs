using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.MySqlDemo.Sessions.Dto;

namespace Acme.MySqlDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
