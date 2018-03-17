using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.HeroShop.Sessions.Dto;

namespace Acme.HeroShop.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
