using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IdentityServerDemo.MultiTenancy.Dto;

namespace IdentityServerDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
