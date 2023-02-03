using Abp.AutoMapper;
using AbpCoreEf7JsonColumnDemo.Sessions.Dto;

namespace AbpCoreEf7JsonColumnDemo.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
