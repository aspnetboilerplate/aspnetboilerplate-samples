using Abp.Application.Services;
using MultipleDbContextEfCoreDemo.MultiTenancy.Dto;

namespace MultipleDbContextEfCoreDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

