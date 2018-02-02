using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.ProjectName.Authorization.Accounts.Dto;

namespace Acme.ProjectName.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
