using Abp.Application.Services;
using InterceptionDemo.MultiTenancy.Dto;

namespace InterceptionDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

