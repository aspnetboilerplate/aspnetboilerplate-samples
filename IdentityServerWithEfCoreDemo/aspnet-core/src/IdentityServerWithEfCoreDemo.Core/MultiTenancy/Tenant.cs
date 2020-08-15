using Abp.MultiTenancy;
using IdentityServerWithEfCoreDemo.Authorization.Users;

namespace IdentityServerWithEfCoreDemo.MultiTenancy
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
