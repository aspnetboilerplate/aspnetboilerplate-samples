using Abp.MultiTenancy;
using Volo.SqliteDemo.Authorization.Users;

namespace Volo.SqliteDemo.MultiTenancy
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
