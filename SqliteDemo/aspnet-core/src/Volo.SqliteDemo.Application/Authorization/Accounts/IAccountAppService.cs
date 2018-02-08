using System.Threading.Tasks;
using Abp.Application.Services;
using Volo.SqliteDemo.Authorization.Accounts.Dto;

namespace Volo.SqliteDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
