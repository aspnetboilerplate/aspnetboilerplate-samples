using System.Threading.Tasks;
using Abp.Application.Services;
using AbpKendoDemo.Authorization.Accounts.Dto;

namespace AbpKendoDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
