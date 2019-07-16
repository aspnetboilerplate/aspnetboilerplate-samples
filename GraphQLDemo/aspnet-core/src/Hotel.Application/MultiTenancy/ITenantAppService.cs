using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hotel.MultiTenancy.Dto;

namespace Hotel.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

