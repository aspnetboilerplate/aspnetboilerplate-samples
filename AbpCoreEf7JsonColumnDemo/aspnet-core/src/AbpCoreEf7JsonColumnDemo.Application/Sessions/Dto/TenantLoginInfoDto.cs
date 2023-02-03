using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpCoreEf7JsonColumnDemo.MultiTenancy;

namespace AbpCoreEf7JsonColumnDemo.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
