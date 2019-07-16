using System.Threading.Tasks;
using Abp.Application.Services;
using Hotel.Authorization.Accounts.Dto;

namespace Hotel.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
