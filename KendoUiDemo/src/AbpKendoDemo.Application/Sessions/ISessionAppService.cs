using System.Threading.Tasks;
using Abp.Application.Services;
using AbpKendoDemo.Sessions.Dto;

namespace AbpKendoDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
