using System.Threading.Tasks;
using Abp.Application.Services;
using Hotel.Sessions.Dto;

namespace Hotel.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
