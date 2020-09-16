using System.Threading.Tasks;
using Abp.Application.Services;
using IdentityServerWithEfCoreDemo.Authorization.Accounts.Dto;

namespace IdentityServerWithEfCoreDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
