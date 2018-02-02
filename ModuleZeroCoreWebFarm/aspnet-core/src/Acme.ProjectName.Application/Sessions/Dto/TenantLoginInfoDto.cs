using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Acme.ProjectName.MultiTenancy;

namespace Acme.ProjectName.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}