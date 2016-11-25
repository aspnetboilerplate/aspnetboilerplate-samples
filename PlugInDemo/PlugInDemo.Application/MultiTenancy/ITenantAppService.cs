using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PlugInDemo.MultiTenancy.Dto;

namespace PlugInDemo.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
