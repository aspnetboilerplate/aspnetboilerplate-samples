using Abp.AutoMapper;
using Acme.MySqlDemo.Sessions.Dto;

namespace Acme.MySqlDemo.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
