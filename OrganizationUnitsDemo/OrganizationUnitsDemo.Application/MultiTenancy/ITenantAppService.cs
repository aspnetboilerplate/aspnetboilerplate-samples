using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OrganizationUnitsDemo.MultiTenancy.Dto;

namespace OrganizationUnitsDemo.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
