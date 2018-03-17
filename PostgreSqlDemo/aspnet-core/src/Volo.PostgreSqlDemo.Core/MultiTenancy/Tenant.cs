using Abp.MultiTenancy;
using Volo.PostgreSqlDemo.Authorization.Users;

namespace Volo.PostgreSqlDemo.MultiTenancy
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
