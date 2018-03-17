using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Acme.HeroShop.MultiTenancy.Dto;

namespace Acme.HeroShop.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
