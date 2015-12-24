using Abp.MultiTenancy;
using OrganizationUnitsDemo.Users;

namespace OrganizationUnitsDemo.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
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