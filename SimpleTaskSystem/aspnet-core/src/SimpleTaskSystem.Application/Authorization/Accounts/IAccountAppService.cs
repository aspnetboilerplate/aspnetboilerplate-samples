using System.Threading.Tasks;
using Abp.Application.Services;
using SimpleTaskSystem.Authorization.Accounts.Dto;

namespace SimpleTaskSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
