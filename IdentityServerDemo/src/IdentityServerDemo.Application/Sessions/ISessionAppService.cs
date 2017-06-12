using System.Threading.Tasks;
using Abp.Application.Services;
using IdentityServerDemo.Sessions.Dto;

namespace IdentityServerDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
