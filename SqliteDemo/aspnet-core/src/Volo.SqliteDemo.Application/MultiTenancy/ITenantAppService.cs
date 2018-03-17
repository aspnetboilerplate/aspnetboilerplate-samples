using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Volo.SqliteDemo.MultiTenancy.Dto;

namespace Volo.SqliteDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
