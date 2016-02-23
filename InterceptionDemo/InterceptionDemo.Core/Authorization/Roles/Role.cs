using Abp.Authorization.Roles;
using InterceptionDemo.MultiTenancy;
using InterceptionDemo.Users;

namespace InterceptionDemo.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}