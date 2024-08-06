using Abp.AutoMapper;
using MultipleDbContextEfCoreDemo.Sessions.Dto;

namespace MultipleDbContextEfCoreDemo.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
