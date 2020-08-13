using System.Threading.Tasks;
using Abp.Application.Services;
using IdentityServervNextDemo.Authorization.Accounts.Dto;

namespace IdentityServervNextDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
