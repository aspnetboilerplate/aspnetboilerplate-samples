using System.Threading.Tasks;
using Abp.Application.Services;
using MassTransitSample.Authorization.Accounts.Dto;

namespace MassTransitSample.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
