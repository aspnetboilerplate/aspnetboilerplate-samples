using Abp.Application.Services;
using MassTransitSample.MultiTenancy.Dto;

namespace MassTransitSample.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

