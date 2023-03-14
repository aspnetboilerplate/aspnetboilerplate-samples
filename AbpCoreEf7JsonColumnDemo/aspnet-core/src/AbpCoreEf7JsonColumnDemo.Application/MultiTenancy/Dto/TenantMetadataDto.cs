using Abp.AutoMapper;

namespace AbpCoreEf7JsonColumnDemo.MultiTenancy.Dto
{
    [AutoMap(typeof(TenantMetadata))]
    public class TenantMetadataDto
    {
        public string LogoId { get; set; }
        
        public string Description { get; set; }
        
        public string Address { get; set; }
    }
}