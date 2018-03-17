using Abp.AutoMapper;
using Volo.PostgreSqlDemo.Sessions.Dto;

namespace Volo.PostgreSqlDemo.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
