using Abp.Application.Services;
using SimpleTaskSystem.MultiTenancy.Dto;

namespace SimpleTaskSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

