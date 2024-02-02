using Abp.Authorization;
using InterceptionDemo.Authorization.Roles;
using InterceptionDemo.Authorization.Users;

namespace InterceptionDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
