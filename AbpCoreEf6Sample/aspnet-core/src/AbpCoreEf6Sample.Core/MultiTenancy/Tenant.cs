using Abp.MultiTenancy;
using AbpCoreEf6Sample.Authorization.Users;

namespace AbpCoreEf6Sample.MultiTenancy
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
    }
}
