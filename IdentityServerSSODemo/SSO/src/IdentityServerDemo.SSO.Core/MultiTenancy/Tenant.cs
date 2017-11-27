using Abp.MultiTenancy;
using IdentityServerDemo.SSO.Authorization.Users;

namespace IdentityServerDemo.SSO.MultiTenancy
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
