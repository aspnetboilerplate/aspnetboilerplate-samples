using Abp.AutoMapper;
using IdentityServerWithEfCoreDemo.Sessions.Dto;

namespace IdentityServerWithEfCoreDemo.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
