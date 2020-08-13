using Abp.AutoMapper;
using IdentityServervNextDemo.Sessions.Dto;

namespace IdentityServervNextDemo.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
