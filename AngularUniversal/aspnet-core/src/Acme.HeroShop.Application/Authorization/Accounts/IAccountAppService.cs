using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.HeroShop.Authorization.Accounts.Dto;

namespace Acme.HeroShop.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
