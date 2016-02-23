using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using InterceptionDemo.MultiTenancy.Dto;

namespace InterceptionDemo.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
