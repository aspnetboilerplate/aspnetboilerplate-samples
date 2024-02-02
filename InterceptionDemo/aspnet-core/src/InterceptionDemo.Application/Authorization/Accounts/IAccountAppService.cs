using System.Threading.Tasks;
using Abp.Application.Services;
using InterceptionDemo.Authorization.Accounts.Dto;

namespace InterceptionDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
