using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpKendoDemo.MultiTenancy.Dto;

namespace AbpKendoDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
