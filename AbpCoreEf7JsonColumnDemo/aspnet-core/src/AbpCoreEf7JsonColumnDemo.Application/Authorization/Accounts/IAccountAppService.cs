using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCoreEf7JsonColumnDemo.Authorization.Accounts.Dto;

namespace AbpCoreEf7JsonColumnDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
