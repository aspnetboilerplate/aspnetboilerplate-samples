using Abp.MultiTenancy;
using Acme.PhoneBook.Authorization.Users;

namespace Acme.PhoneBook.MultiTenancy
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