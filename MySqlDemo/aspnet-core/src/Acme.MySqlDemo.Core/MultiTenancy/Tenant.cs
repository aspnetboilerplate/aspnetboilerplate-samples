using Abp.MultiTenancy;
using Acme.MySqlDemo.Authorization.Users;

namespace Acme.MySqlDemo.MultiTenancy
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
