using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.PhoneBook.Authorization.Accounts.Dto;

namespace Acme.PhoneBook.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
