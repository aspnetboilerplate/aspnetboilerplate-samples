using Abp.MultiTenancy;
using MultipleDbContextEfCoreDemo.Authorization.Users;

namespace MultipleDbContextEfCoreDemo.MultiTenancy
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
