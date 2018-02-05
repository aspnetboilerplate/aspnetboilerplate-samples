using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.MySqlDemo.Authorization.Accounts.Dto;

namespace Acme.MySqlDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
