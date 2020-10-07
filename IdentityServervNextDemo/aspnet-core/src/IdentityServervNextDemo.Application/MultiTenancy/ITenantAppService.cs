using Abp.Application.Services;
using IdentityServervNextDemo.MultiTenancy.Dto;

namespace IdentityServervNextDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

