using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Acme.PhoneBook.MultiTenancy.Dto;

namespace Acme.PhoneBook.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
