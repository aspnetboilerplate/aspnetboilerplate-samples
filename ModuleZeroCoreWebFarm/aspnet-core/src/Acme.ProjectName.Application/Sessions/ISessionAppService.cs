using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.ProjectName.Sessions.Dto;

namespace Acme.ProjectName.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
