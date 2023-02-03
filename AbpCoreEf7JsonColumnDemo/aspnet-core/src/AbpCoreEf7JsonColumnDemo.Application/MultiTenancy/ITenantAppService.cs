using Abp.Application.Services;
using AbpCoreEf7JsonColumnDemo.MultiTenancy.Dto;

namespace AbpCoreEf7JsonColumnDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

