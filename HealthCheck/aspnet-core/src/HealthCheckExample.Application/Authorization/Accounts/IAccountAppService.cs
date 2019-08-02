using System.Threading.Tasks;
using Abp.Application.Services;
using HealthCheckExample.Authorization.Accounts.Dto;

namespace HealthCheckExample.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
