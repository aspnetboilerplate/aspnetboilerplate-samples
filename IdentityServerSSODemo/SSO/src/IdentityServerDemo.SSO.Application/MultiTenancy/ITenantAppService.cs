using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IdentityServerDemo.SSO.MultiTenancy.Dto;

namespace IdentityServerDemo.SSO.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
