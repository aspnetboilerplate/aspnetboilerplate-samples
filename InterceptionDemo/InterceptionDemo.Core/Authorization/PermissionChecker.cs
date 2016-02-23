using Abp.Authorization;
using InterceptionDemo.Authorization.Roles;
using InterceptionDemo.MultiTenancy;
using InterceptionDemo.Users;

namespace InterceptionDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
