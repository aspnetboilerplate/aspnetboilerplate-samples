using System.Threading.Tasks;
using Abp.Application.Services;
using Volo.PostgreSqlDemo.Authorization.Accounts.Dto;

namespace Volo.PostgreSqlDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
