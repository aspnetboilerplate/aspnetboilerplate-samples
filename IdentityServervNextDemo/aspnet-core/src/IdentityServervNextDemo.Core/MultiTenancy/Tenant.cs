using Abp.MultiTenancy;
using IdentityServervNextDemo.Authorization.Users;

namespace IdentityServervNextDemo.MultiTenancy
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
