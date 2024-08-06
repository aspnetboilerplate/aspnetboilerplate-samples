using System.Threading.Tasks;
using Abp.Application.Services;
using MultipleDbContextEfCoreDemo.Authorization.Accounts.Dto;

namespace MultipleDbContextEfCoreDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
