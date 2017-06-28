using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using InterceptionDemo.MultiTenancy.Dto;

namespace InterceptionDemo.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
