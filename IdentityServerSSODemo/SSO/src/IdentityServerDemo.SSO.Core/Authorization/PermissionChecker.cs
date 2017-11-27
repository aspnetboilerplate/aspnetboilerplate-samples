using Abp.Authorization;
using IdentityServerDemo.SSO.Authorization.Roles;
using IdentityServerDemo.SSO.Authorization.Users;

namespace IdentityServerDemo.SSO.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
