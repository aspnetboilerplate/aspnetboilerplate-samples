using Abp.MultiTenancy;
using AbpCoreEf7JsonColumnDemo.Authorization.Users;

namespace AbpCoreEf7JsonColumnDemo.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }

        public TenantMetadata Metadata { get; set; }
    }
}
