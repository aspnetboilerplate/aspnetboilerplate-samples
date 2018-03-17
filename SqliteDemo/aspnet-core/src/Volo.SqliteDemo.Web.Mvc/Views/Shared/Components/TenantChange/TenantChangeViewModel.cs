using Abp.AutoMapper;
using Volo.SqliteDemo.Sessions.Dto;

namespace Volo.SqliteDemo.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
