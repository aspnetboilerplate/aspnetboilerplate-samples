using Abp.Authorization;
using IdentityServerWithEfCoreDemo.Authorization.Roles;
using IdentityServerWithEfCoreDemo.Authorization.Users;

namespace IdentityServerWithEfCoreDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
