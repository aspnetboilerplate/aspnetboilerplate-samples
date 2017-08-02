using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.PhoneBook.Sessions.Dto;

namespace Acme.PhoneBook.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
