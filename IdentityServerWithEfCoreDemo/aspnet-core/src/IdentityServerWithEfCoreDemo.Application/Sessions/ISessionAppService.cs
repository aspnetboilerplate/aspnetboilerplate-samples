using System.Threading.Tasks;
using Abp.Application.Services;
using IdentityServerWithEfCoreDemo.Sessions.Dto;

namespace IdentityServerWithEfCoreDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
