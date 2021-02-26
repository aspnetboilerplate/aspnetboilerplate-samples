using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCoreEf6Sample.Authorization.Accounts.Dto;

namespace AbpCoreEf6Sample.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
