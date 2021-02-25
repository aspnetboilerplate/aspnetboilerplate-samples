using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCoreEf6Sample.Sessions.Dto;

namespace AbpCoreEf6Sample.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
