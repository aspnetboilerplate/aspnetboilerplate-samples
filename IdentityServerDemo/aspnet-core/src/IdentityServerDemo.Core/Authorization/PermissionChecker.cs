using Abp.Authorization;
using IdentityServerDemo.Authorization.Roles;
using IdentityServerDemo.Authorization.Users;

namespace IdentityServerDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
