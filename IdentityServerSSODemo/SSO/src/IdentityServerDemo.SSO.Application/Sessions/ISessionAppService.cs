using System.Threading.Tasks;
using Abp.Application.Services;
using IdentityServerDemo.SSO.Sessions.Dto;

namespace IdentityServerDemo.SSO.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
