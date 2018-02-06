using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Acme.MySqlDemo.MultiTenancy.Dto;

namespace Acme.MySqlDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
