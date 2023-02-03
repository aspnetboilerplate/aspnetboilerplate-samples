using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCoreEf7JsonColumnDemo.Sessions.Dto;

namespace AbpCoreEf7JsonColumnDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
