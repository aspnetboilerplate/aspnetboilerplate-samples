using Abp.Application.Services;
using AbpCoreEf6Sample.MultiTenancy.Dto;

namespace AbpCoreEf6Sample.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

