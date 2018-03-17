using Abp.MultiTenancy;
using Acme.HeroShop.Authorization.Users;

namespace Acme.HeroShop.MultiTenancy
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
