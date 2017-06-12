using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IdentityServerDemo.MultiTenancy.Dto;

namespace IdentityServerDemo.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
