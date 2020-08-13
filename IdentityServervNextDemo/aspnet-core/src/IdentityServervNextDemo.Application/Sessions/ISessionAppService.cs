using System.Threading.Tasks;
using Abp.Application.Services;
using IdentityServervNextDemo.Sessions.Dto;

namespace IdentityServervNextDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
