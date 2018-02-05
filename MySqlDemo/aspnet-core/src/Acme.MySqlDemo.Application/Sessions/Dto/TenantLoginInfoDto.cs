using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Acme.MySqlDemo.MultiTenancy;

namespace Acme.MySqlDemo.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
