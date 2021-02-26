using Abp.AutoMapper;
using AbpCoreEf6Sample.Sessions.Dto;

namespace AbpCoreEf6Sample.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
