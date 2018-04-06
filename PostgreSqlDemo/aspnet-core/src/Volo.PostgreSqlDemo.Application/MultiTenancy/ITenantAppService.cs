using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Volo.PostgreSqlDemo.MultiTenancy.Dto;

namespace Volo.PostgreSqlDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
