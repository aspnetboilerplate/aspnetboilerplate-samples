using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BackgroundJobAndNotificationsDemo.MultiTenancy.Dto;

namespace BackgroundJobAndNotificationsDemo.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
