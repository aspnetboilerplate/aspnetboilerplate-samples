using Abp.Application.Services;
using IdentityServerWithEfCoreDemo.MultiTenancy.Dto;

namespace IdentityServerWithEfCoreDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

