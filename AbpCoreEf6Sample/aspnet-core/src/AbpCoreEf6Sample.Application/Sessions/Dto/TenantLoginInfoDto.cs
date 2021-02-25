using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpCoreEf6Sample.MultiTenancy;

namespace AbpCoreEf6Sample.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
