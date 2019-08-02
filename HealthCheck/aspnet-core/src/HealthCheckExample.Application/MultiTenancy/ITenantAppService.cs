using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HealthCheckExample.MultiTenancy.Dto;

namespace HealthCheckExample.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

